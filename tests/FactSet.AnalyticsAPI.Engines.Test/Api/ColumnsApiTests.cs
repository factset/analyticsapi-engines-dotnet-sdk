using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class ColumnsApiTests
    {
        private ColumnsApi columnsApi;

        [TestInitialize]
        public void Init()
        {
            columnsApi = new ColumnsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void ColumnsApi_GetAllColumns_Success()
        {
            var apiResponse = columnsApi.GetPAColumnsWithHttpInfo();

            Assert.IsTrue(apiResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsInstanceOfType(apiResponse.Data, typeof(Dictionary<string, ColumnSummary>), "Response should be Dictionary of ColumnSummary.");
            Assert.IsTrue(apiResponse.Data != null, "Response data should not be null.");
        }

        [TestMethod]
        public void ColumnsApi_GetById_Success()
        {
            var columnId = CommonFunctions.GetRandomColumnId();
            var apiResponse = columnsApi.GetPAColumnByIdWithHttpInfo(columnId);

            Assert.IsTrue(apiResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsInstanceOfType(apiResponse.Data, typeof(Column), "Response should be of Column type.");
            Assert.IsTrue(apiResponse.Data != null, "Response data should not be null.");
        }
    }
}
