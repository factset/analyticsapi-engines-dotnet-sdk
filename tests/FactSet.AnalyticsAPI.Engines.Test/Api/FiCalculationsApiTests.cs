using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class FiCalculationsApiTests
    {
        private FICalculationsApi fiCalculationsApi;

        [TestInitialize]
        public void Init()
        {
            fiCalculationsApi = new FICalculationsApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void CalculationsWorkflow_Should_Succeed_When_GivenValidInputs()
        {
            var calculations = new List<string>();
            var securities = new List<FISecurity>();

            var jobSettings = new FIJobSettings(asOfDate: "20201201");

            var fiCalculationParameters = new FICalculationParameters(securities, calculations, jobSettings);
            var fiCalculationParametersRoot = new FICalculationParametersRoot(data: fiCalculationParameters);

            Console.WriteLine(JsonConvert.SerializeObject(fiCalculationParametersRoot));

            try
            {

                var postAndOptimizeHttpResponse =
                    fiCalculationsApi.PostAndCalculateWithHttpInfo(fICalculationParametersRoot: fiCalculationParametersRoot);

                postAndOptimizeHttpResponse.StatusCode
                    .Should()
                    .Match<HttpStatusCode>(c => c == HttpStatusCode.Created || c == HttpStatusCode.Accepted);

                switch (postAndOptimizeHttpResponse.StatusCode)
                {
                    case HttpStatusCode.Accepted:
                        var optimizationId =
                            postAndOptimizeHttpResponse.Headers["X-Factset-Api-Calculation-Id"].First();
                        bool shouldPoll;
                        do
                        {
                            var pollingResponse = fiCalculationsApi.GetCalculationStatusByIdWithHttpInfo(optimizationId);
                            pollingResponse.StatusCode
                                .Should()
                                .Match<HttpStatusCode>(c =>
                                    c == HttpStatusCode.Created || c == HttpStatusCode.Accepted);

                            shouldPoll = pollingResponse.StatusCode == HttpStatusCode.Accepted;

                            if (pollingResponse.Headers.ContainsKey("Cache-Control"))
                            {
                                var maxAge = pollingResponse.Headers["Cache-Control"][0];
                                if (string.IsNullOrWhiteSpace(maxAge))
                                {
                                    Console.WriteLine("Sleeping for 2 seconds");
                                    // Sleep for at least 2 seconds.
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    var age = int.Parse(maxAge.Replace("max-age=", ""));
                                    Console.WriteLine($"Sleeping for {age} seconds");
                                    Thread.Sleep(age * 1000);
                                }
                            }

                        } while (shouldPoll);

                        var getResultResponse = fiCalculationsApi.GetCalculationResultWithHttpInfo(optimizationId);
                        getResultResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                        getResultResponse.Data.Should().NotBeNull();
                        break;
                    case HttpStatusCode.Created:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}