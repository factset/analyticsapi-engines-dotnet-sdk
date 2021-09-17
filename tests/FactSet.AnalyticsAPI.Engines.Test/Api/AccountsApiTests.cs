using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;
using System;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class AccountsApiTests
    {
        private AccountsApi accountsApi;

        [TestInitialize]
        public void Init()
        {
            accountsApi = new AccountsApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void AccountsApi_Get_Accounts_List_Success()
        {
            ApiResponse<AccountDirectoriesRoot> response = accountsApi.GetAccountsWithHttpInfo(CommonParameters.DefaultLookupDirectory);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(response.Data != null, "Response data should not be null");
            Assert.IsTrue(response.Data.GetType() == typeof(AccountDirectoriesRoot), "Response Data should be of AccountDirectoriesRoot type");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(AccountDirectories), "Response Data should be of AccountDirectories type");
        }
    }
}
