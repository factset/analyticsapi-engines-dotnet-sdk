﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach.Extensions;
using FactSet.Protobuf.Stach.V2;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class PACalculationsApiTests
    {
        private PACalculationsApi calculationsApi;
        private ComponentsApi componentsApi;
        private int pageNumber;

        [TestInitialize]
        public void Init()
        {
            calculationsApi = new PACalculationsApi(CommonFunctions.BuildConfiguration());
            componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration());
            pageNumber = 1;
        }

        private ApiResponse<object> RunCalculation()
        {
            var paComponents = componentsApi.GetPAComponentsWithHttpInfo(CommonParameters.PADefaultDocument);

            var paComponentId = paComponents.Data.Data.Keys.First();
            var paAccountIdentifier = new PAIdentifier(CommonParameters.PABenchmarkSP50);
            var paAccounts = new List<PAIdentifier> { paAccountIdentifier };
            var paBenchmarkIdentifier = new PAIdentifier(CommonParameters.PABenchmarkR1000);
            var paBenchmarks = new List<PAIdentifier> { paBenchmarkIdentifier };

            var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks);

            var parameters = new PACalculationParametersRoot
            {
                Data = new Dictionary<string, PACalculationParameters> { { "1", paCalculation }, { "2", paCalculation } }
            };

            var response = calculationsApi.PostAndCalculateWithHttpInfo(null, "max-stale=0", parameters);

            return response;
        }

        [TestMethod]
        public void EnginesApi_Get_PA_Calculation_Success()
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

                var stachBuilder = StachExtensionFactory.GetRowOrganizedBuilder();
                stachBuilder.SetPackage(resultResponse.Data.Data);

                Assert.IsInstanceOfType(stachBuilder.GetPackage(), typeof(RowOrganizedPackage), "Result response data should be of type RowOrganizedPackage.");
            }
        }

        [TestMethod]
        public void EnginesApi_Delete_PA_Calculation_Success()
        {
            var calculationResponse = RunCalculation();

            Assert.IsTrue(calculationResponse.StatusCode == HttpStatusCode.Accepted, "Create response status code should be 202 - Accepted.");

            CalculationStatusRoot calculationStatus = (CalculationStatusRoot)calculationResponse.Data;

            var calculationId = calculationStatus.Data.Calculationid;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId), "Create response calculation id should be present.");

            var deleteResponse = calculationsApi.CancelCalculationByIdWithHttpInfo(calculationId);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.NoContent, "Delete response status code should be 204 - No Content.");
            Assert.IsTrue(deleteResponse.Data == null, "Response data should be null.");
        }

        [TestMethod]
        public void EnginesAPi_GetAll_PA_Calculations_Success()
        {
            var calculationsResponse = calculationsApi.GetAllCalculationsWithHttpInfoAsync(pageNumber);
            Assert.IsTrue(calculationsResponse.Result.StatusCode == HttpStatusCode.OK, "Result response status code should be 200 - OK.");
        }
    }
}
