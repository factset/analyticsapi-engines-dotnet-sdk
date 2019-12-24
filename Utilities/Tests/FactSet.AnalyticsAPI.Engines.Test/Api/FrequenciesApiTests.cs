using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class FrequenciesApiTests
    {
        private FrequenciesApi _frequenciesApi;

        [TestInitialize]
        public void Init()
        {
            _frequenciesApi = new FrequenciesApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void FrequenciesApi_Get_PAFrequencies_Success()
        {
            var paFrequenciesResponse = _frequenciesApi.GetPAFrequenciesWithHttpInfo();

            Assert.IsTrue(paFrequenciesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(paFrequenciesResponse.Data.GetType() == typeof(Dictionary<string, Frequency>), "Response result should be of Frequency Dictionary type.");
            Assert.IsTrue(paFrequenciesResponse.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void FrequenciesApi_Get_SPARFrequencies_Success()
        {
            var sparFrequenciesResponse = _frequenciesApi.GetSPARFrequenciesWithHttpInfo();

            Assert.IsTrue(sparFrequenciesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(sparFrequenciesResponse.Data.GetType() == typeof(Dictionary<string, Frequency>), "Response result should be of Frequency Dictionary type.");
            Assert.IsTrue(sparFrequenciesResponse.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void FrequenciesApi_Get_VaultFrequencies_Success()
        {
            var vaultFrequenciesResponse = _frequenciesApi.GetVaultFrequenciesWithHttpInfo();

            Assert.IsTrue(vaultFrequenciesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(vaultFrequenciesResponse.Data.GetType() == typeof(Dictionary<string, Frequency>), "Response result should be of Frequency Dictionary type.");
            Assert.IsTrue(vaultFrequenciesResponse.Data.Count != 0, "Response data should not be null.");
        }
    }
}
