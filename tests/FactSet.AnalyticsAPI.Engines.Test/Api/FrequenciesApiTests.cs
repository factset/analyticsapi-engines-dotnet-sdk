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
        private FrequenciesApi frequenciesApi;

        [TestInitialize]
        public void Init()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void FrequenciesApi_Get_PAFrequencies_Success()
        {
            frequenciesApi = new FrequenciesApi(CommonFunctions.BuildConfiguration());
            var paFrequenciesResponse = frequenciesApi.GetPAFrequenciesWithHttpInfo();

            Assert.IsTrue(paFrequenciesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(paFrequenciesResponse.Data.Data.GetType() == typeof(Dictionary<string, Frequency>), "Response result should be of Frequency Dictionary type.");
            Assert.IsTrue(paFrequenciesResponse.Data.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void FrequenciesApi_Get_SPARFrequencies_Success()
        {
            frequenciesApi = new FrequenciesApi(CommonFunctions.BuildConfiguration());
            var sparFrequenciesResponse = frequenciesApi.GetSPARFrequenciesWithHttpInfo();

            Assert.IsTrue(sparFrequenciesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(sparFrequenciesResponse.Data.Data.GetType() == typeof(Dictionary<string, Frequency>), "Response result should be of Frequency Dictionary type.");
            Assert.IsTrue(sparFrequenciesResponse.Data.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void FrequenciesApi_Get_VaultFrequencies_Success()
        {
            frequenciesApi = new FrequenciesApi(CommonFunctions.BuildConfiguration());
            var vaultFrequenciesResponse = frequenciesApi.GetVaultFrequenciesWithHttpInfo();

            Assert.IsTrue(vaultFrequenciesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(vaultFrequenciesResponse.Data.Data.GetType() == typeof(Dictionary<string, Frequency>), "Response result should be of Frequency Dictionary type.");
            Assert.IsTrue(vaultFrequenciesResponse.Data.Data.Count != 0, "Response data should not be null.");
        }
    }
}
