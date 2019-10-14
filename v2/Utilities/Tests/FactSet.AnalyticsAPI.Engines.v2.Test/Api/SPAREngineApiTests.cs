using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Client;
using FactSet.AnalyticsAPI.Engines.v2.Model;

using FactSet.Protobuf.Stach;
using Google.Protobuf;

namespace FactSet.AnalyticsAPI.Engines.v2.Test.Api
{
    [TestClass]
    public class SPAREngineApiTests
    {
        private CalculationsApi _calculationsApi;
        private UtilityApi _utilityApi;
        private ComponentsApi _componentsApi;

        [TestInitialize]
        public void Init()
        {
            _calculationsApi = new CalculationsApi(CommonFunctions.BuildConfiguration());
            _utilityApi = new UtilityApi(CommonFunctions.BuildConfiguration());
            _componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration());
        }

        private ApiResponse<object> RunCalculation()
        {
            var parameters = new Calculation();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var sparComponents = _componentsApi.GetSPARComponentsWithHttpInfo(CommonParameters.SPARDefaultDocument);
            var sparComponentId = sparComponents.Data.Keys.First();
            var sparAccountIdentifier = new SPARIdentifier(CommonParameters.SPARBenchmarkR1000, CommonParameters.SPARBenchmarkRussellReturnType, CommonParameters.SPARBenchmarkRussellPrefix);
            var sparAccounts = new List<SPARIdentifier> { sparAccountIdentifier };
            var sparBenchmarkIdentifier = new SPARIdentifier(CommonParameters.SPARBenchmarkRussellPR2000, CommonParameters.SPARBenchmarkRussellReturnType, CommonParameters.SPARBenchmarkRussellPrefix);

            var sparCalculation = new SPARCalculationParameters(sparComponentId, sparAccounts, sparBenchmarkIdentifier);
            parameters.Spar = new Dictionary<string, SPARCalculationParameters> { { "1", sparCalculation } };

            var response = _calculationsApi.RunCalculationWithHttpInfo(parameters);

            return response;
        }

        [TestMethod]
        public void EnginesApi_Get_Calculation_Success()
        {
            var runCalculationResponse = RunCalculation();

            Assert.IsTrue(runCalculationResponse.StatusCode == HttpStatusCode.Accepted, "Create response status code should be 202 - Created.");

            var id = runCalculationResponse.Headers["Location"][0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(id), "Create response calculation id should be present.");

            runCalculationResponse.Headers.TryGetValue("Location", out var location);
            var calculationId = location?[0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            ApiResponse<CalculationStatus> getStatus = null;

            while (getStatus == null || getStatus.Data.Status == CalculationStatus.StatusEnum.Queued || getStatus.Data.Status == CalculationStatus.StatusEnum.Executing)
            {
                if (getStatus != null)
                {
                    Assert.IsTrue(getStatus.Data != null, "Response Data should not be null.");
                    Assert.IsTrue(getStatus.Data.Status == CalculationStatus.StatusEnum.Executing || getStatus.Data.Status == CalculationStatus.StatusEnum.Queued, "Response Data should have batch status as processing or queued.");

                    if (getStatus.Headers.ContainsKey("Cache-Control"))
                    {
                        var maxAge = getStatus.Headers["Cache-Control"][0];
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

                getStatus = _calculationsApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
            }

            Assert.IsTrue(getStatus.Data.Status == CalculationStatus.StatusEnum.Completed, "Response Data should have calculation status as completed.");
            Assert.IsTrue(getStatus.Data.Spar.Values.All(s => s.Status == CalculationUnitStatus.StatusEnum.Success), "Response Data should have all Spar calculations status as completed.");

            Assert.IsTrue(getStatus.Data.Spar.Values.All(s => s.Result != null), "Response Data should have all Spar Calculation results.");

            foreach (var sparCalculationParameters in getStatus.Data.Spar.Values)
            {
                ApiResponse<string> resultResponse = null;
                resultResponse = _utilityApi.GetByUrlWithHttpInfo(sparCalculationParameters.Result);

                Assert.IsTrue(resultResponse.StatusCode == HttpStatusCode.OK, "Result response status code should be 200 - OK.");
                Assert.IsTrue(resultResponse.Data != null, "Result response data should not be null.");

                var jpSettings = JsonParser.Settings.Default;
                var jp = new JsonParser(jpSettings.WithIgnoreUnknownFields(true));
                var package = jp.Parse<Package>(resultResponse.Data);

                Assert.IsInstanceOfType(package, typeof(Package), "Result response data should be of type Package.");
            }
        }

        [TestMethod]
        public void EnginesApi_Delete_Calculation_Success()
        {
            var runCalculationResponse = RunCalculation();

            Assert.IsTrue(runCalculationResponse.StatusCode == HttpStatusCode.Accepted, "Create response status code should be 202 - Created.");

            var calculationId = runCalculationResponse.Headers["Location"][0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId), "Create response calculation id should be present.");

            var deleteResponse = _calculationsApi.CancelCalculationByIdWithHttpInfo(calculationId);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.NoContent, "Delete response status code should be 204 - No Content.");
            Assert.IsTrue(deleteResponse.Data == null, "Response data should be null.");
        }

        [TestMethod]
        public void EnginesApi_Get_CalculationStatusSummaries_Success()
        {
            var runCalculationResponse = RunCalculation();

            Assert.IsTrue(runCalculationResponse.StatusCode == HttpStatusCode.Accepted, "Create response status code should be 202 - Created.");

            var calculationId = runCalculationResponse.Headers["Location"][0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId), "Create response calculation id should be present.");

            var getCalculationStatusSummariesResponse = _calculationsApi.GetCalculationStatusSummariesWithHttpInfo();

            Assert.IsTrue(getCalculationStatusSummariesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - Success");
            Assert.IsInstanceOfType(getCalculationStatusSummariesResponse, typeof(ApiResponse<Dictionary<string, CalculationStatusSummary>>), "Response result should be dictionary of string and CalculationStatusSummary");
            Assert.IsTrue(getCalculationStatusSummariesResponse.Data != null, "Response Data should not be null");

            var deleteResponse = _calculationsApi.CancelCalculationByIdWithHttpInfo(calculationId);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.NoContent, "Delete response status code should be 204 - No Content.");
            Assert.IsTrue(deleteResponse.Data == null, "Response data should be null.");
        }
    }
}
