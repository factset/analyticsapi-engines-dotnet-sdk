using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class AccountsApiTests
    {
        private AccountsApi _accountsApi;

        [TestInitialize]
        public void Init()
        {
            _accountsApi = new AccountsApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void AccountsApi_Get_Accounts_List_Success()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ApiResponse<AccountDirectories> response = _accountsApi.GetAccountsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(AccountDirectories), "Response Data should be of AccountDirectories type");
        }
    }
}
