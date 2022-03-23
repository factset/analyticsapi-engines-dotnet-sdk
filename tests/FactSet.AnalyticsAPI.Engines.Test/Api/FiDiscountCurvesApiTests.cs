using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Collections.Generic;
using System.IO;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class FiDiscountCurvesApiTests
    {
        private DiscountCurvesApi discountCurvesApi;

        [TestInitialize]
        public void Init()
        {
            discountCurvesApi = new DiscountCurvesApi(CommonFunctions.BuildConfiguration());
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [TestMethod]
        public void DiscountCurvesApi_Get_Success()
        {
            var response = discountCurvesApi.GetAllFIDiscountCurvesWithHttpInfo();
        
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(Dictionary<string, FIDiscountCurveInfo>), "Response result should be dictionary of Currency and FI Discount Curve Info.");
            Assert.IsTrue(response.Data.Data.Count > 0, "Response result should not be an empty dictionary.");
        }
        
        [TestMethod]
        public void DiscountCurvesApi_Get_Success_Currency_INR()
        {
            var response = discountCurvesApi.GetAllFIDiscountCurvesWithHttpInfo("INR");
        
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK, "Response Should be 200 - OK");
            Assert.IsTrue(response.Data.Data.GetType() == typeof(Dictionary<string, FIDiscountCurveInfo>), "Response result should be dictionary of Currency and FI Discount Curve Info.");
            Assert.IsTrue(response.Data.Data.Count > 0, "Response result should not be an empty dictionary.");
        }
        
        [TestMethod]
        [ExpectedException(typeof(Client.ApiException),
             "Error getting discount curves for given currency.")]
        public void DiscountCurvesApi_Get_Currency_Invalid()
        {
            discountCurvesApi.GetAllFIDiscountCurvesWithHttpInfo("InvalidCurrency");
        }
    }
}
