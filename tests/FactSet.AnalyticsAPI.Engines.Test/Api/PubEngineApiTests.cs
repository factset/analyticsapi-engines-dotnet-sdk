using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class PubEngineApiTests
    {
        private CalculationsApi _calculationsApi;
        private UtilityApi _utilityApi;

        [TestInitialize]
        public void Init()
        {
            _calculationsApi = new CalculationsApi(CommonFunctions.BuildConfiguration(Engine.PUB));
            _utilityApi = new UtilityApi(CommonFunctions.BuildConfiguration(Engine.PUB));
        }

        private ApiResponse<object> RunCalculation()
        {
            var parameters = new Calculation();

            var pubAccountIdentifier = new PubIdentifier(CommonParameters.PubAccountName);
            var pubDateParameters = new PubDateParameters(CommonParameters.PubStartDate, CommonParameters.PubEndDate);

            var pubCalculation = new PubCalculationParameters(CommonParameters.PubDocumentName, pubAccountIdentifier,
                pubDateParameters);
            parameters.Pub = new Dictionary<string, PubCalculationParameters> { { "1", pubCalculation } };

            var response = _calculationsApi.RunCalculationWithHttpInfo(parameters);

            return response;
        }

        [TestMethod]
        public void EnginesApi_Get_Calculation_Success()
        {
            var runCalculationResponse = RunCalculation();

            Assert.IsTrue(runCalculationResponse.StatusCode == HttpStatusCode.Accepted,
                "Create response status code should be 202 - Created.");

            var id = runCalculationResponse.Headers["Location"][0]
                .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(id), "Create response calculation id should be present.");

            runCalculationResponse.Headers.TryGetValue("Location", out var location);
            var calculationId = location?[0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            ApiResponse<CalculationStatus> getStatus = null;

            while (getStatus == null || getStatus.Data.Status == CalculationStatus.StatusEnum.Queued ||
                   getStatus.Data.Status == CalculationStatus.StatusEnum.Executing)
            {
                if (getStatus != null)
                {
                    Assert.IsTrue(getStatus.Data != null, "Response Data should not be null.");
                    Assert.IsTrue(
                        getStatus.Data.Status == CalculationStatus.StatusEnum.Executing ||
                        getStatus.Data.Status == CalculationStatus.StatusEnum.Queued,
                        "Response Data should have batch status as processing or queued.");

                    if (getStatus.Headers.ContainsKey("Cache-Control") &&
                        !string.IsNullOrWhiteSpace(getStatus.Headers["Cache-Control"][0]))
                    {
                        var maxAge = getStatus.Headers["Cache-Control"][0];
                        var age = int.Parse(maxAge.Replace("max-age=", ""));
                        Console.WriteLine($"Sleeping for {age} seconds");
                        Thread.Sleep(age * 1000);
                    }
                    else
                    {
                        Console.WriteLine("Sleeping for 2 seconds");
                        // Sleep for at least 2 seconds.
                        Thread.Sleep(2000);
                    }
                }

                getStatus = _calculationsApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
            }

            Assert.IsTrue(getStatus.Data.Status == CalculationStatus.StatusEnum.Completed,
                "Response Data should have calculation status as completed.");
            Assert.IsTrue(getStatus.Data.Pub.Values.All(p => p.Status == CalculationUnitStatus.StatusEnum.Success),
                "Response Data should have all PA calculations status as completed.");

            Assert.IsTrue(getStatus.Data.Pub.Values.All(p => p.Result != null),
                "Response Data should have all PA Calculation results.");

            foreach (var calculationParameters in getStatus.Data.Pub.Values)
            {
                var resultResponse = _utilityApi.GetByUrlWithHttpInfo(calculationParameters.Result);

                Assert.IsTrue(resultResponse.StatusCode == HttpStatusCode.OK,
                    "Result response status code should be 200 - OK.");
                Assert.IsTrue(resultResponse.RawContent != null, "Result response data should not be null.");
                Assert.AreEqual("application/pdf", resultResponse.Headers["Content-Type"][0], "Invalid content type");
            }
        }

        [TestMethod]
        public void EnginesApi_Delete_Calculation_Success()
        {
            var runCalculationResponse = RunCalculation();

            Assert.IsTrue(runCalculationResponse.StatusCode == HttpStatusCode.Accepted,
                "Create response status code should be 202 - Created.");

            var calculationId = runCalculationResponse.Headers["Location"][0]
                .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId),
                "Create response calculation id should be present.");

            var deleteResponse = _calculationsApi.CancelCalculationByIdWithHttpInfo(calculationId);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.NoContent,
                "Delete response status code should be 204 - No Content.");
            Assert.IsTrue(deleteResponse.Data == null, "Response data should be null.");
        }

        [TestMethod]
        public void EnginesApi_Get_CalculationStatusSummaries_Success()
        {
            var runCalculationResponse = RunCalculation();

            Assert.IsTrue(runCalculationResponse.StatusCode == HttpStatusCode.Accepted,
                "Create response status code should be 202 - Created.");

            var calculationId = runCalculationResponse.Headers["Location"][0]
                .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId),
                "Create response calculation id should be present.");

            var getCalculationStatusSummariesResponse = _calculationsApi.GetCalculationStatusSummariesWithHttpInfo();

            Assert.IsTrue(getCalculationStatusSummariesResponse.StatusCode == HttpStatusCode.OK,
                "Response should be 200 - Success");
            Assert.IsInstanceOfType(getCalculationStatusSummariesResponse,
                typeof(ApiResponse<Dictionary<string, CalculationStatusSummary>>),
                "Response result should be dictionary of string and CalculationStatusSummary");
            Assert.IsTrue(getCalculationStatusSummariesResponse.Data != null, "Response Data should not be null");

            var deleteResponse = _calculationsApi.CancelCalculationByIdWithHttpInfo(calculationId);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.NoContent,
                "Delete response status code should be 204 - No Content.");
            Assert.IsTrue(deleteResponse.Data == null, "Response data should be null.");
        }
    }
}