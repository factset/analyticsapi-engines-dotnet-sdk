using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class ComponentsApiTests
    {
        private ComponentsApi componentsApi;

        [TestInitialize]
        public void Init()
        {
            componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void ComponentsApi_Get_PAComponents_Success()
        {
            var componentGetAllResponse = componentsApi.GetPAComponentsWithHttpInfo(CommonParameters.PADefaultDocument);

            Assert.IsTrue(componentGetAllResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(componentGetAllResponse.Data.Data.GetType() == typeof(Dictionary<string, ComponentSummary>), "Response result should be of ComponentSummary Dictionary type.");
            Assert.IsTrue(componentGetAllResponse.Data.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void ComponentsApi_Get_PAComponentById_Success()
        {
            var paComponents = componentsApi.GetPAComponentsWithHttpInfo(CommonParameters.PADefaultDocument);
            var paComponentId = paComponents.Data.Data.Keys.First();

            var componentGetByIdResponse = componentsApi.GetPAComponentByIdWithHttpInfo(paComponentId);

            Assert.IsTrue(componentGetByIdResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(componentGetByIdResponse.Data.Data != null, "Response data should not be null");
            Assert.IsTrue(componentGetByIdResponse.Data.Data.GetType() == typeof(PAComponent), "Response result should be of PAComponent type");
        }

        [TestMethod]
        public void ComponentsApi_Get_VaultComponents_Success()
        {
            var componentGetAllResponse = componentsApi.GetVaultComponentsWithHttpInfo(CommonParameters.VaultDefaultDocument);

            Assert.IsTrue(componentGetAllResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(componentGetAllResponse.Data.Data.GetType() == typeof(Dictionary<string, ComponentSummary>), "Response result should be of ComponentSummary Dictionary type.");
            Assert.IsTrue(componentGetAllResponse.Data.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void ComponentsApi_Get_VaultComponentById_Success()
        {
            var vaultComponents = componentsApi.GetVaultComponentsWithHttpInfo(CommonParameters.VaultDefaultDocument);
            var vaultComponentId = vaultComponents.Data.Data.Keys.First();

            var componentGetByIdResponse = componentsApi.GetVaultComponentByIdWithHttpInfo(vaultComponentId);

            Assert.IsTrue(componentGetByIdResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(componentGetByIdResponse.Data.Data != null, "Response data should not be null");
            Assert.IsTrue(componentGetByIdResponse.Data.Data.GetType() == typeof(VaultComponent), "Response result should be of VaultComponent type");
        }

        [TestMethod]
        public void ComponentsApi_Get_SparComponents_Success()
        {
            var componentGetAllResponse = componentsApi.GetSPARComponentsWithHttpInfo(CommonParameters.SPARDefaultDocument);

            Assert.IsTrue(componentGetAllResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(componentGetAllResponse.Data.Data.GetType() == typeof(Dictionary<string, ComponentSummary>), "Response result should be of ComponentSummary Dictionary type.");
            Assert.IsTrue(componentGetAllResponse.Data.Data.Count != 0, "Response data should not be null.");
        }

        [TestMethod]
        public void ComponentsApi_Get_SPARComponentById_Success()
        {
            var sparComponents = componentsApi.GetSPARComponentsWithHttpInfo(CommonParameters.SPARDefaultDocument);
            var sparComponentId = sparComponents.Data.Data.Keys.First();

            var componentGetByIdResponse = componentsApi.GetSPARComponentByIdWithHttpInfo(sparComponentId);

            Assert.IsTrue(componentGetByIdResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(componentGetByIdResponse.Data.Data != null, "Response data should not be null");
            Assert.IsTrue(componentGetByIdResponse.Data.Data.GetType() == typeof(SPARComponent), "Response result should be of SPARComponent type");
        }
    }
}
