using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class GroupsApiTests
    {
        private GroupsApi groupsApi;

        [TestInitialize]
        public void Init()
        {
            groupsApi = new GroupsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void GroupsApi_Get_Success()
        {
            var groupResponse = groupsApi.GetPAGroupsWithHttpInfo();

            Assert.IsTrue(groupResponse.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(groupResponse.Data.Data.GetType() == typeof(Dictionary<string, Group>), "Response result should be a Group Dictionary.");
            Assert.IsTrue(groupResponse.Data.Data.Count > 0, "Response result should not be an empty Dictionary.");
        }
    }
}
