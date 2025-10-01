using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;
using System.IO;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class QuantCalculationsApiTests
    {
        private QuantCalculationsApi calculationsApi;
        private int pageNumber;

        [TestInitialize]
        public void Init()
        {
            calculationsApi = new QuantCalculationsApi(CommonFunctions.BuildConfiguration());
            pageNumber = 1;
        }
                
        [TestMethod]
        public void EnginesApi_Quant_Get_Calculation_Success()
        {
            var calculationResponse = EnginesApi_Quant_RunCalculation();
            ProcessCalculations(calculationResponse);
        }

        [TestMethod]
        public void EnginesApi_Quant_Single_Unit_Calculation_With_Warnings()
        {
            var calculationResponse = EnginesApi_Quant_RunCalculation(expectedWarningsInResponse: true);
            ProcessCalculations(calculationResponse);
        }

        [TestMethod]
        public void EnginesAPi_Quant_GetAll_Calculations_Success()
        {
            var calculationsResponse = calculationsApi.GetAllCalculationsWithHttpInfoAsync(pageNumber);
            Assert.IsTrue(calculationsResponse.Result.StatusCode == HttpStatusCode.OK, "Result response status code should be 200 - OK.");
        }              
        
        [TestMethod]
        public void EnginesApi_Quant_IsArrayReturnType_Get_Calculation_Success()
        {
            var calculationResponse = EnginesApi_Quant_IsArrayReturnType_RunCalculation();
            ProcessCalculations(calculationResponse);
        }

        private ApiResponse<object> EnginesApi_Quant_RunCalculation(bool expectedWarningsInResponse = false)
        {
            var oneOfQuantUniverse = new OneOfQuantUniverse(new QuantScreeningExpressionUniverse("ISON_DOW", QuantScreeningExpressionUniverse.UniverseTypeEnum.Equity, "TICKER", QuantScreeningExpressionUniverse.SourceEnum.ScreeningExpressionUniverse));
            var oneOfQuantDates = new OneOfQuantDates(new QuantFdsDate("0", "-5D", QuantFdsDate.SourceEnum.FdsDate, "D", "FIVEDAY"));

            string expr = expectedWarningsInResponse ? "FF_MKT_VAL(AN_R,0,RP,USD)" : "P_PRICE(#DATE,#DATE-5D,#FREQ)" ;
            
            var oneOfQuantFormulases = new List<OneOfQuantFormulas>()
            {
                new OneOfQuantFormulas(new QuantScreeningExpression(expr : "P_PRICE", name : "Price (SCR)", source : QuantScreeningExpression.SourceEnum.ScreeningExpression)),
                new OneOfQuantFormulas(new QuantFqlExpression(expr : "P_PRICE", name : "Price (SCR)",  source : QuantFqlExpression.SourceEnum.FqlExpression)),
                new OneOfQuantFormulas(new QuantFqlExpression(expr : expr, name : "Price", isArrayReturnType : false,  source : QuantFqlExpression.SourceEnum.FqlExpression))
            };

            var quantCalculation = new QuantCalculationParameters(universe: oneOfQuantUniverse, dates: oneOfQuantDates, formulas: oneOfQuantFormulases);

            var quantCalculationsMeta = new QuantCalculationMeta(format: QuantCalculationMeta.FormatEnum.Feather);

            var calculationParameters = new QuantCalculationParametersRoot
            {
                Data = new Dictionary<string, QuantCalculationParameters> { { "1", quantCalculation } },
                Meta = quantCalculationsMeta
            };

            var response = calculationsApi.PostAndCalculateWithHttpInfo("max-stale=0", calculationParameters);

            return response;
        }

        private ApiResponse<object> EnginesApi_Quant_IsArrayReturnType_RunCalculation()
        {
            var oneOfQuantUniverse = new OneOfQuantUniverse(new QuantIdentifierUniverse(
                QuantIdentifierUniverse.UniverseTypeEnum.Equity,
                new List<string> { "03748R74", "S8112735" },
                QuantIdentifierUniverse.SourceEnum.IdentifierUniverse));
            var oneOfQuantDates = new OneOfQuantDates(new QuantFdsDate("0", "-5D", QuantFdsDate.SourceEnum.FdsDate, "D", "FIVEDAY"));
            var oneOfQuantFormulases = new List<OneOfQuantFormulas>()
            {
                new OneOfQuantFormulas(new QuantScreeningExpression(expr : "P_PRICE", name : "Price (SCR)", source : QuantScreeningExpression.SourceEnum.ScreeningExpression)),
                new OneOfQuantFormulas(new QuantFqlExpression(expr : "P_PRICE", name : "Price (SCR)",  source : QuantFqlExpression.SourceEnum.FqlExpression)),
                new OneOfQuantFormulas(new QuantFqlExpression(expr : "P_PRICE(#DATE,#DATE-5D,#FREQ)", name : "Price", isArrayReturnType : true,  source : QuantFqlExpression.SourceEnum.FqlExpression))
            };

            var quantCalculation = new QuantCalculationParameters(universe: oneOfQuantUniverse, dates: oneOfQuantDates, formulas: oneOfQuantFormulases);

            var quantCalculationsMeta = new QuantCalculationMeta(format: QuantCalculationMeta.FormatEnum.Feather);

            var calculationParameters = new QuantCalculationParametersRoot
            {
                Data = new Dictionary<string, QuantCalculationParameters> { { "1", quantCalculation } },
                Meta = quantCalculationsMeta
            };

            var response = calculationsApi.PostAndCalculateWithHttpInfo("max-stale=0", calculationParameters);

            return response;
        }

        private void ProcessCalculations(ApiResponse<object> calculationResponse)
        {
            Assert.IsTrue(calculationResponse.StatusCode == HttpStatusCode.Accepted, "Create response status code should be 202 - Accepted.");

            CalculationStatusRoot calculationStatus = (CalculationStatusRoot)calculationResponse.Data;

            var calculationId = calculationStatus.Data.Calculationid;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId), "Create response calculation id should be present.");

            ApiResponse<CalculationStatusRoot> getStatusResponse = null;

            while (calculationStatus.Data.Status == CalculationStatus.StatusEnum.Queued || calculationStatus.Data.Status == CalculationStatus.StatusEnum.Executing)
            {
                if (getStatusResponse != null)
                {
                    Assert.IsTrue(getStatusResponse.Data != null, "Response Data should not be null.");
                    Assert.IsTrue(getStatusResponse.Data.Data.Status == CalculationStatus.StatusEnum.Executing || getStatusResponse.Data.Data.Status == CalculationStatus.StatusEnum.Queued, "Response Data should have batch status as processing or queued.");

                    if (getStatusResponse.Headers.ContainsKey("Cache-Control"))
                    {
                        var maxAge = getStatusResponse.Headers["Cache-Control"][0];
                        if (string.IsNullOrWhiteSpace(maxAge))
                        {
                            var age = int.TryParse(CommonParameters.Quant_Custom_Max_Age, out int ageValue) ? ageValue : 2;
                            
                            Console.WriteLine($"Sleeping for {age} seconds");
                            Thread.Sleep(age * 1000);
                        }
                        else
                        {
                            var age = int.Parse(maxAge.Replace("max-age=", ""));

                            // setting minimum sleep time to 10 seconds.
                            age = age <= 10 ? 10 : age;

                            Console.WriteLine($"Sleeping for {age} seconds");
                            Thread.Sleep(age * 1000);
                        }
                    }
                }

                getStatusResponse = calculationsApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                calculationStatus = getStatusResponse.Data;
            }

            Assert.IsTrue(calculationStatus.Data.Status == CalculationStatus.StatusEnum.Completed, "Response Data should have calculation status as completed.");
            Assert.IsTrue(calculationStatus.Data.Units.Values.All(p => p.Status == CalculationUnitStatus.StatusEnum.Success), "Response Data should have all calculations status as completed.");
            
            // When unit response contains warnings.
            calculationStatus.Data.Units.TryGetValue("1", out CalculationUnitStatus calculationUnitStatus);
            if (calculationUnitStatus.Warnings != null)
            {
                Assert.IsTrue(calculationStatus.Data.Units.Values.All(p => p.Warnings.Count != 0), "Unit Status should have warnings.");
                Assert.IsTrue(calculationStatus.Data.Units.Values.All(p => p.Warnings[0] != null), "Unit Status with warnings should have a reason.");
            }

            Assert.IsTrue(calculationStatus.Data.Units.Values.All(p => p.Result != null), "Response Data should have all Calculation results.");

            foreach (var calculation in calculationStatus.Data.Units)
            {
                var resultResponse = calculationsApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, calculation.Key);

                Assert.IsTrue(resultResponse.StatusCode == HttpStatusCode.OK, "Result response status code should be 200 - OK.");
                Assert.IsTrue(resultResponse.Data != null, "Result response data should not be null.");

                Assert.IsInstanceOfType(resultResponse.Data, typeof(Stream), "Result response data should be of type Stream.");

                var infoResponse = calculationsApi.GetCalculationUnitInfoByIdWithHttpInfo(calculationId, calculation.Key);

                Assert.IsTrue(resultResponse.StatusCode == HttpStatusCode.OK, "Result response status code should be 200 - OK.");
                Assert.IsTrue(resultResponse.Data != null, "Result response data should not be null.");

                Assert.IsInstanceOfType(resultResponse.Data, typeof(Stream), "Result response data should be of type Stream.");
            }
        }
    }
}
