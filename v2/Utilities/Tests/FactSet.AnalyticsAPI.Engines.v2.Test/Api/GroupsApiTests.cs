using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Model;

namespace FactSet.AnalyticsAPI.Engines.v2.Test.Api
{
    [TestClass]
    public class GroupsApiTests
    {
        private GroupsApi _groupsApi;

        [TestInitialize]
        public void Init()
        {
            _groupsApi = new GroupsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void GroupsApi_Get_Success()
        {
            var groupResponse = _groupsApi.GetPAGroupsWithHttpInfo();

            Assert.IsTrue(groupResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(groupResponse.Data.GetType() == typeof(Dictionary<string, Group>), "Response result should be a Group Dictionary.");
            Assert.IsTrue(groupResponse.Data.Count > 0, "Response result should not be an empty Dictionary.");
        }
    }
}
