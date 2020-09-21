using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach;
using Google.Protobuf;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class PAEngineInteractiveApiTests
    {
        private PACalculationsApi _calculationsApi;
        private ComponentsApi _componentsApi;

        [TestInitialize]
        public void Init()
        {
            _calculationsApi = new PACalculationsApi(CommonFunctions.BuildConfiguration(Engine.PA));
            _componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration(Engine.PA));
        }

        private ApiResponse<object> RunCalculation()
        {
            var paComponents = _componentsApi.GetPAComponentsWithHttpInfo(CommonParameters.PADefaultDocument);

            var paComponentId = paComponents.Data.Keys.First();
            var paAccountIdentifier = new PAIdentifier(CommonParameters.PABenchmarkSP50);
            var paAccounts = new List<PAIdentifier> { paAccountIdentifier };
            var paBenchmarkIdentifier = new PAIdentifier(CommonParameters.PABenchmarkSP50PF);
            var paBenchmarks = new List<PAIdentifier> { paBenchmarkIdentifier };

            var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks);

            var response = _calculationsApi.RunPACalculationWithHttpInfo(paCalculation);

            return response;
        }

        [TestMethod]
        public void EnginesApi_Get_Calculation_Success()
        {
            var runCalculationResponse = RunCalculation();

            var calculationId = string.Empty;

            while (runCalculationResponse.StatusCode == HttpStatusCode.Accepted)
            {
                if (string.IsNullOrWhiteSpace(calculationId))
                {
                    runCalculationResponse.Headers.TryGetValue("Location", out var location);
                    calculationId = location?[0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId),
                        "Create response calculation id should be present.");
                }

                if (runCalculationResponse.Headers.ContainsKey("Cache-Control") &&
                    runCalculationResponse.Headers["Cache-Control"][0] is var maxAge &&
                    !string.IsNullOrWhiteSpace(maxAge))
                {
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

                runCalculationResponse = _calculationsApi.GetPACalculationByIdWithHttpInfo(calculationId);
            }

            Assert.IsTrue(
                runCalculationResponse.StatusCode == HttpStatusCode.Created ||
                runCalculationResponse.StatusCode == HttpStatusCode.OK,
                "Create response status code should be 200 or 201.");

            Assert.IsTrue(runCalculationResponse.Data != null, "Result response data should not be null.");

            var jpSettings = JsonParser.Settings.Default;
            var jp = new JsonParser(jpSettings.WithIgnoreUnknownFields(true));
            var package = jp.Parse<Package>(runCalculationResponse.Data.ToString());

            Assert.IsInstanceOfType(package, typeof(Package), "Result response data should be of type Package.");
        }
    }
}