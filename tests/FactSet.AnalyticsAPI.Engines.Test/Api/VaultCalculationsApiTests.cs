using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class VaultCalculationsApiTests
    {
        private VaultCalculationsApi vaultCalculationsApi;
        private ComponentsApi componentsApi;
        private ConfigurationsApi configurationsApi;

        [TestInitialize]
        public void Init()
        {
            vaultCalculationsApi = new VaultCalculationsApi(CommonFunctions.BuildConfiguration());
            componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration());
            configurationsApi = new ConfigurationsApi(CommonFunctions.BuildConfiguration());
        }

        private ApiResponse<object> RunCalculation()
        {
            var vaultComponents = componentsApi.GetVaultComponentsWithHttpInfo(CommonParameters.VaultDefaultDocument);
            var vaultComponentId = vaultComponents.Data.Data.Keys.First();
            
            var vaultConfigurations = configurationsApi.GetVaultConfigurationsWithHttpInfo(CommonParameters.VaultDefaultAccount);
            var vaultConfigurationsId = vaultConfigurations.Data.Data.Keys.First();

            var vaultAccount = new VaultIdentifier(CommonParameters.VaultDefaultAccount);
            var vaultDates = new VaultDateParameters(CommonParameters.VaultStartDate, CommonParameters.VaultEndDate, "Monthly");

            var vaultCalculationParameters = new VaultCalculationParameters(vaultComponentId, vaultAccount, vaultDates, vaultConfigurationsId);

            var parameters = new VaultCalculationParametersRoot
            {
                Data = new Dictionary<string, VaultCalculationParameters> { { "1", vaultCalculationParameters }, { "2", vaultCalculationParameters } }
            };

            var response = vaultCalculationsApi.PostAndCalculateWithHttpInfo(null, "max-stale=0", parameters);

            return response;
        }

        [TestMethod]
        public void EnginesApi_Get_Vault_Calculation_Success()
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

                getStatusResponse = vaultCalculationsApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                calculationStatus = getStatusResponse.Data;
            }

            Assert.IsTrue(calculationStatus.Data.Status == CalculationStatus.StatusEnum.Completed, "Response Data should have calculation status as completed.");
            Assert.IsTrue(calculationStatus.Data.Units.Values.All(p => p.Status == CalculationUnitStatus.StatusEnum.Success), "Response Data should have all Vault calculations status as completed.");

            Assert.IsTrue(calculationStatus.Data.Units.Values.All(p => p.Result != null), "Response Data should have all Vault Calculation results.");

            foreach (var calculation in calculationStatus.Data.Units)
            {
                var resultResponse = vaultCalculationsApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, calculation.Key);

                Assert.IsTrue(resultResponse.StatusCode == HttpStatusCode.OK, "Result response status code should be 200 - OK.");
                Assert.IsTrue(resultResponse.Data != null, "Result response data should not be null.");

                var stachBuilder = StachExtensionFactory.GetRowOrganizedBuilder();
                stachBuilder.SetPackage(resultResponse.Data.Data);

                Assert.IsInstanceOfType(stachBuilder.GetPackage(), typeof(RowOrganizedPackage), "Result response data should be of type RowOrganizedPackage.");
            }
        }

        [TestMethod]
        public void EnginesApi_Delete_Vault_Calculation_Success()
        {
            var calculationResponse = RunCalculation();

            Assert.IsTrue(calculationResponse.StatusCode == HttpStatusCode.Accepted, "Create response status code should be 202 - Accepted.");

            CalculationStatusRoot calculationStatus = (CalculationStatusRoot)calculationResponse.Data;

            var calculationId = calculationStatus.Data.Calculationid;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(calculationId), "Create response calculation id should be present.");

            var deleteResponse = vaultCalculationsApi.CancelCalculationByIdWithHttpInfo(calculationId);

            Assert.IsTrue(deleteResponse.StatusCode == HttpStatusCode.NoContent, "Delete response status code should be 204 - No Content.");
            Assert.IsTrue(deleteResponse.Data == null, "Response data should be null.");
        }
    }
}
