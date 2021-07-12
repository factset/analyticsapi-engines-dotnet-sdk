using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class ColumnsStatisticsApiTests
    {
        private ColumnStatisticsApi columnStatisticsApi;

        [TestInitialize]
        public void Init()
        {
            columnStatisticsApi = new ColumnStatisticsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void ColumnStatisticsApi_GetAll_Success()
        {
            var apiResponse = columnStatisticsApi.GetPAColumnStatisticsWithHttpInfo();

            Assert.IsTrue(apiResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(apiResponse.Data.Data.GetType() == typeof(Dictionary<string, ColumnStatistic>), "Repsponse should be Dictionary of ColumnStatistic.");
            Assert.IsTrue(apiResponse.Data != null, "Response data should not be null.");
        }
    }
}
