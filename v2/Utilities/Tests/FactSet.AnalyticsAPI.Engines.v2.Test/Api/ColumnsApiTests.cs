using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Model;

namespace FactSet.AnalyticsAPI.Engines.v2.Test.Api
{
    [TestClass]
    public class ColumnsApiTests
    {
        private ColumnsApi _columnsApi;

        [TestInitialize]
        public void Init()
        {
            _columnsApi = new ColumnsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void ColumnsApi_GetAllColumns_Success()
        {
            var apiResponse = _columnsApi.GetPAColumnsWithHttpInfo();

            Assert.IsTrue(apiResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsInstanceOfType(apiResponse.Data, typeof(Dictionary<string, ColumnSummary>), "Response should be Dictionary of ColumnSummary.");
            Assert.IsTrue(apiResponse.Data != null, "Response data should not be null.");
        }

        [TestMethod]
        public void ColumnsApi_GetById_Success()
        {
            var columnId = CommonFunctions.GetRandomColumnId();
            var apiResponse = _columnsApi.GetPAColumnByIdWithHttpInfo(columnId);

            Assert.IsTrue(apiResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsInstanceOfType(apiResponse.Data, typeof(Column), "Response should be of Column type.");
            Assert.IsTrue(apiResponse.Data != null, "Response data should not be null.");
        }
    }
}
