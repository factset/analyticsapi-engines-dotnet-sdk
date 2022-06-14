using FactSet.AnalyticsAPI.Engines.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class PricingSourcesApiTests
    {
        private PricingSourcesApi pricingSourcesApi;

        [TestInitialize]
        public void Init()
        {
            pricingSourcesApi = new PricingSourcesApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void PricingSourcesApi_Get_Success()
        {
            var pricingSourcesResponse = pricingSourcesApi.GetPAPricingSourcesWithHttpInfo();

            Assert.IsTrue(pricingSourcesResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(pricingSourcesResponse.Data.Data.Count > 0, "Response result should not be an empty Dictionary.");
        }
    }
}
