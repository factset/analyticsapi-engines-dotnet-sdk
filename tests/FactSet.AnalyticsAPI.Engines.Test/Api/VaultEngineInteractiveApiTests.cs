using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    public class VaultEngineInteractiveApiTests
    {
        private VaultCalculationsApi _calculationsApi;
        private ComponentsApi _componentsApi;
        private ConfigurationsApi _configurationsApi;

        [TestInitialize]
        public void Init()
        {
            _calculationsApi = new VaultCalculationsApi(CommonFunctions.BuildConfiguration(Engine.VAULT));
            _componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration(Engine.VAULT));
            _configurationsApi = new ConfigurationsApi(CommonFunctions.BuildConfiguration(Engine.VAULT));
        }

        private ApiResponse<object> RunCalculation()
        {
            var vaultComponents = _componentsApi.GetVaultComponentsWithHttpInfo(CommonParameters.VaultDefaultDocument);

            var vaultComponentId = vaultComponents.Data.Keys.First();
            var vaultAccountIdentifier = new VaultIdentifier(CommonParameters.VaultDefaultAccount);
            var vaultDates = new VaultDateParameters(CommonParameters.VaultStartDate, CommonParameters.VaultEndDate, CommonParameters.VaultFrequency);
            var vaultConfiguration = _configurationsApi.GetVaultConfigurationsWithHttpInfo(CommonParameters.VaultDefaultAccount);
            var vaultConfigurationId = vaultConfiguration.Data.Keys.First();

            var paCalculation = new VaultCalculationParameters(vaultComponentId, vaultAccountIdentifier, vaultDates, vaultConfigurationId);

            var response = _calculationsApi.RunVaultCalculationWithHttpInfo(paCalculation);

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

                runCalculationResponse = _calculationsApi.GetVaultCalculationByIdWithHttpInfo(calculationId);
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