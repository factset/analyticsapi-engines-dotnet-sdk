using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class DocumentsApiTests
    {
        private DocumentsApi _documentsApi;

        [TestInitialize]
        public void Init()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void DocumentsApi_Get_PA3Documents_List_Success()
        {
            _documentsApi = new DocumentsApi(CommonFunctions.BuildConfiguration(Engine.PA));
            var response = _documentsApi.GetPA3DocumentsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(DocumentDirectories), "Response Data should be of DocumentDirectories type");
        }

        [TestMethod]
        public void DocumentsApi_Get_VaultDocuments_List_Success()
        {
            _documentsApi = new DocumentsApi(CommonFunctions.BuildConfiguration(Engine.VAULT));
            var response = _documentsApi.GetVaultDocumentsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(DocumentDirectories), "Response Data should be of DocumentDirectories type");
        }

        [TestMethod]
        public void DocumentsApi_Get_SPARDocuments_List_Success()
        {
            _documentsApi = new DocumentsApi(CommonFunctions.BuildConfiguration(Engine.SPAR));
            var response = _documentsApi.GetSPAR3DocumentsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(DocumentDirectories), "Response Data should be of DocumentDirectories type");
        }
    }
}
