using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;
using System.Collections.Generic;
using System.Net;


namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
   public class LinkedPATemplatesApiTest
    {
            
        private LinkedPATemplatesApi linkedPATemplates;


        [TestInitialize]
        public void Init()
        {
            linkedPATemplates = new LinkedPATemplatesApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void Test_CreateLinkedPATemplate()
        {
            const string directory = "Personal:SDKTests/DoNotModify/LinkedPATemplates/";
            const string parentComponenIid = "801B800245E468A52AEBEC4BE31CFF5AF82F371DAEF5F158AC2E98C2FA324B46";
            const string description = "This is a linked PA template that only returns security level data";
            List<string> mandatory = new List<string>(2);
            mandatory.Add("accounts");
            mandatory.Add("benchmarks");
            List<string> optional = new List<string>(2);
            optional.Add("groups");
            optional.Add("columns");
            List<string> locked = new List<string>(2);
            locked.Add("componentdetail");

            var content = new TemplateContentTypes(mandatory, optional, locked);

            var linkedPATemplatesParameter = new LinkedPATemplateParameters(directory, parentComponenIid, description, content);

            var linkedPATemplatesParameterRoot = new LinkedPATemplateParametersRoot(linkedPATemplatesParameter);

            ApiResponse<LinkedPATemplatePostSummaryRoot> response = linkedPATemplates.CreateLinkedPATemplatesWithHttpInfo(linkedPATemplatesParameterRoot);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created, "Response should be 201 - Success");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(LinkedPATemplatePostSummary), "Response should be of LinkedPATemplatePostSummary type.");
            Assert.IsTrue(response.Data.Data.Id.GetType() == typeof(string), "Response should be of String type.");
            Assert.IsTrue(response.Data.Data.Id.Length > 0 , "Response result should not be an empty list.");



        }
        [TestMethod]
        public void Test_GetAllLinkedPATemplate()
        {
            const string directory = "Personal:SDKTests/DoNotModify/LinkedPATemplates/";
            ApiResponse<LinkedPATemplateSummaryRoot> response = linkedPATemplates.GetLinkedPATemplatesWithHttpInfo(directory);
            List<string> templatelist = response.Data.Data.Keys.ToList();
            string firstTemplate = templatelist[0];

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - Success");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(Dictionary<string, LinkedPATemplateSummary>), "Response should be of Dictionary type.");
            Assert.IsTrue(response.Data.Data[firstTemplate].GetType() == typeof(LinkedPATemplateSummary), "Response should be of LinkedPATemplateSummary type.");
            Assert.IsTrue(response.Data.Data.Count > 0, "Response result should not be an empty list.");

        }
        [TestMethod]
        public void Test_Update_LinkedPA_Templates() 
        {
            const string directory = "Personal:SDKTests/DoNotModify/LinkedPATemplates/";
            const string parentComponentId = "801B800245E468A52AEBEC4BE31CFF5AF82F371DAEF5F158AC2E98C2FA324B46";
            const string description = "This is an updated linked PA template that only returns security level data";
            ApiResponse<LinkedPATemplateSummaryRoot> templates = linkedPATemplates.GetLinkedPATemplatesWithHttpInfo(directory);
            List<string> templatesId = templates.Data.Data.Keys.ToList();
            var linkedPATemplateUpdateParameters = new LinkedPATemplateUpdateParameters(parentComponentId, description);
            
            List<string> mandatory = new List<string>(2);
            mandatory.Add("accounts");
            mandatory.Add("benchmarks");
            List<string> optional = new List<string>(2);
            optional.Add("groups");
            optional.Add("columns");
            List<string> locked = new List<string>(2);
            locked.Add("componentdetail");
            
            var content = new TemplateContentTypes(mandatory, optional, locked);
            var linkedPATemplateUpdateParametersRoot = new LinkedPATemplateUpdateParametersRoot(linkedPATemplateUpdateParameters);
            
            ApiResponse<LinkedPATemplatePostSummaryRoot> response = linkedPATemplates.UpdateLinkedPATemplatesWithHttpInfo(templatesId[0],linkedPATemplateUpdateParametersRoot);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - Success");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(LinkedPATemplatePostSummary), "Response should be of LinkedPATemplatePostSummary type.");
            Assert.IsTrue(response.Data.Data.Id.Length > 0, "Response result should not be an empty list.");

        }
        [TestMethod]
        public void Test_GetLinkedPATemplatesById()

        {
            const string directory = "Personal:SDKTests/DoNotModify/LinkedPATemplates/";

            ApiResponse<LinkedPATemplateSummaryRoot> templates = linkedPATemplates.GetLinkedPATemplatesWithHttpInfo(directory);
            List<string> templatesId = templates.Data.Data.Keys.ToList();
            ApiResponse<LinkedPATemplateRoot> response = linkedPATemplates.GetLinkedPATemplatesByIdWithHttpInfo(templatesId[0]);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - Success");
            Assert.IsTrue(response.Data.GetType() == typeof(LinkedPATemplateRoot), "Response should be of LinkedPATemplateRoot type.");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(LinkedPATemplate),"Response should be of LinkedPaTemplate type");

        }
        [TestMethod]
        public void Test_DeleteLinkedPATemplates()
        {
            const string directory = "Personal:SDKTests/DoNotModify/LinkedPATemplates/";

            ApiResponse<LinkedPATemplateSummaryRoot> templates = linkedPATemplates.GetLinkedPATemplatesWithHttpInfo(directory);
            List<string> templatesId = templates.Data.Data.Keys.ToList();

            ApiResponse<object> response = linkedPATemplates.DeleteLinkedPATemplatesWithHttpInfo(templatesId[0]);
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent, "Response should be 204 - Success");

        }

    }
}
