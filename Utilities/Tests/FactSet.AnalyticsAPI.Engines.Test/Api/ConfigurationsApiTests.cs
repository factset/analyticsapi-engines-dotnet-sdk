using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.Linq;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class ConfigurationsApiTests
    {
        private ConfigurationsApi _configurationsApi;

        [TestInitialize]
        public void Init()
        {
            _configurationsApi = new ConfigurationsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void ConfigurationsApi_Get_Configuration_Success()
        {
            var account = CommonParameters.VaultDefaultAccount;

            var response = _configurationsApi.GetVaultConfigurationsWithHttpInfo(account);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response code is 200 - OK");
            Assert.IsInstanceOfType(response.Data, typeof(Dictionary<string, VaultConfigurationSummary>), "Response is of type Dictionary<string, VaultConfigurationSummary>");
        }

        [TestMethod]
        public void ConfigurationsApi_GetConfigurationsById_Success()
        {
            var vaultConfiguration = _configurationsApi.GetVaultConfigurationsWithHttpInfo(CommonParameters.VaultDefaultAccount);
            var vaultConfigurationId = vaultConfiguration.Data.Keys.First();

            var response = _configurationsApi.GetVaultConfigurationByIdWithHttpInfo(vaultConfigurationId);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response code is 200 - OK");
            Assert.IsInstanceOfType(response.Data, typeof(VaultConfiguration), "Response is of type VaultConfiguration");
        }
    }
}
