﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class DatesApiTests
    {
        private DatesApi datesApi;
        private ComponentsApi componentsApi;

        [TestInitialize]
        public void Init()
        {
            datesApi = new DatesApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void DatesApi_PADatesToAbsoluteFormat_Success()
        {
            var endDate = "-1M";
            // Hard coding this as we won't know if the component requires start date
            var componentId = "918EE8207D259B54E2FDE2AAA4D3BEA9248164123A904F298B8438B76F9292EB";
            var account = CommonParameters.DefaultDatesAccount;

            var datesResponse = datesApi.ConvertPADatesToAbsoluteFormatWithHttpInfo(endDate, componentId, account);

            Assert.IsTrue(datesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(datesResponse.Data.Data.GetType() == typeof(DateParametersSummary), "Response Should be of DateParametersSummary type.");
            Assert.IsTrue(datesResponse.Data.Data != null, "Response data should not be null");
        }

        [TestMethod]
        public void DatesApi_VaultDatesToAbsoluteFormat_Success()
        {
            componentsApi = new ComponentsApi(CommonFunctions.BuildConfiguration());
            var endDate = "-1M";
            var account = CommonParameters.VaultDefaultAccount;
            var vaultComponents = componentsApi.GetVaultComponentsWithHttpInfo(CommonParameters.VaultDefaultDocument);
            var vaultComponentId = vaultComponents.Data.Data.Keys.First();

            var datesResponse = datesApi.ConvertVaultDatesToAbsoluteFormatWithHttpInfo(endDate, vaultComponentId, account);

            Assert.IsTrue(datesResponse.StatusCode == HttpStatusCode.OK, "Response should be 200 - OK");
            Assert.IsTrue(datesResponse.Data.Data.GetType() == typeof(DateParametersSummary), "Response Should be of DateParametersSummary type.");
            Assert.IsTrue(datesResponse.Data.Data != null, "Response data should not be null");
        }
    }
}
