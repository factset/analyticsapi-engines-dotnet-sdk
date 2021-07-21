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

        [TestInitialize]
        public void Init()
        {
            calculationsApi = new QuantCalculationsApi(CommonFunctions.BuildConfiguration());
        }

        private ApiResponse<object> RunCalculation()
        {
            var screeningExpressionUniverse = new QuantScreeningExpressionUniverse("ISON_DOW", QuantScreeningExpressionUniverse.UniverseTypeEnum.Equity, "TICKER");
            var fdsDate = new QuantFdsDate("0", "-5D", "D", "FIVEDAY");
            var screeningExpression = new List<QuantScreeningExpression>()
            {
                new QuantScreeningExpression("P_PRICE", "Price (SCR)")
            };
            var fqlExpression = new List<QuantFqlExpression>()
            {
                new QuantFqlExpression("P_PRICE", "Price (SCR)")
            };

            var quantCalculation = new QuantCalculationParameters(screeningExpressionUniverse: screeningExpressionUniverse, fdsDate: fdsDate, screeningExpression: screeningExpression, fqlExpression: fqlExpression);

            var quantCalculationsMeta = new QuantCalculationMeta(format: QuantCalculationMeta.FormatEnum.Feather);

            var calculationParameters = new QuantCalculationParametersRoot
            {
                Data = new Dictionary<string, QuantCalculationParameters> { { "1", quantCalculation } },
                Meta = quantCalculationsMeta
            };

            var response = calculationsApi.PostAndCalculateWithHttpInfo("max-stale=0", calculationParameters);

            return response;
        }

        [TestMethod]
        public void EnginesApi_Get_Calculation_Success()
        {
            var calculationResponse = RunCalculation();

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
                            Console.WriteLine("Sleeping for 2 seconds");
                            // Sleep for at least 2 seconds.
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            var age = int.Parse(maxAge.Replace("max-age=", ""));
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
