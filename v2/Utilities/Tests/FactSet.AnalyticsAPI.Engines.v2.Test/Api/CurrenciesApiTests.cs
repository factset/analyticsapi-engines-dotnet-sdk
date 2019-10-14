using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Model;

namespace FactSet.AnalyticsAPI.Engines.v2.Test.Api
{
    [TestClass]
    public class CurrenciesApiTests
    {
        private CurrenciesApi _currenciesApi;

        [TestInitialize]
        public void Init()
        {
            _currenciesApi = new CurrenciesApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void CurrenciesApi_Get_Success()
        {
            var response = _currenciesApi.GetPACurrenciesWithHttpInfo();

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(response.Data.GetType() == typeof(Dictionary<string, Currency>), "Response result should be dictionary of ISO code and currency names.");
            Assert.IsTrue(response.Data.Count > 0, "Response result should not be an empty dictionary.");
        }
    }
}
