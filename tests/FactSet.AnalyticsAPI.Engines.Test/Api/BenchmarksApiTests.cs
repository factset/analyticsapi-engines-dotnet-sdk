using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class BenchmarksApiTests
    {
        private BenchmarksApi benchmarksApi;

        [TestInitialize]
        public void Init()
        {
            benchmarksApi = new BenchmarksApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]    
        public void BenchmarksApi_Get_SPAR_Benchmarks_Success()
        {
            ApiResponse<SPARBenchmarkRoot> response = benchmarksApi.GetSPARBenchmarkByIdWithHttpInfo(CommonParameters.SPARBenchmarkR1000);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(SPARBenchmarkRoot), "Response Data should be of SPARBenchmarkRoot type");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(SPARBenchmark), "Response Data should be of SPARBenchmark type");
        }
    }
}
