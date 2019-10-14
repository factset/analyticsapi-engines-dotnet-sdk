using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Model;

namespace FactSet.AnalyticsAPI.Engines.v2.Test.Api
{
    [TestClass]
    public class DocumentsApiTests
    {
        private DocumentsApi _documentsApi;

        [TestInitialize]
        public void Init()
        {
            _documentsApi = new DocumentsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void DocumentsApi_Get_PA3Documents_List_Success()
        {
            var response = _documentsApi.GetPA3DocumentsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(DocumentDirectories), "Response Data should be of DocumentDirectories type");
        }

        [TestMethod]
        public void DocumentsApi_Get_VaultDocuments_List_Success()
        {
            var response = _documentsApi.GetVaultDocumentsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(DocumentDirectories), "Response Data should be of DocumentDirectories type");
        }

        [TestMethod]
        public void DocumentsApi_Get_SPARDocuments_List_Success()
        {
            var response = _documentsApi.GetSPAR3DocumentsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(DocumentDirectories), "Response Data should be of DocumentDirectories type");
        }
    }
}
