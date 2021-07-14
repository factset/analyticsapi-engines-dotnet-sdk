using System;
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
    public class BpmCalculationsApiTests
    {
        private BPMOptimizerApi bpmOptimizerApi;

        [TestInitialize]
        public void Init()
        {
            bpmOptimizerApi = new BPMOptimizerApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void OptimizerWorkflow_Should_Succeed_When_GivenValidInputs()
        {
            const string strategyId = "CLIENT:/Aapi/Optimizers/BPMAPISIMPLE";
            const string accountId = "BENCH:SP50";
            const string riskModelDate = "09/01/2008";
            var bpmStrategy = new BPMOptimizerStrategy(null, strategyId);
            var bpmAccount = new OptimizerAccount(accountId);
            var optimization = new BPMOptimization(riskModelDate, backtestDate : "09/01/2008");
            var tradesList = new OptimizerTradesList(OptimizerTradesList.IdentifierTypeEnum.Asset, false);
            var outputTypes = new OptimizerOutputTypes(tradesList);

            var bpmCalculationParameters = new BPMOptimizationParameters(bpmStrategy, optimization, bpmAccount, outputTypes);
            var bpmCalculationParametersRoot = new BPMOptimizationParametersRoot(bpmCalculationParameters);

            Console.WriteLine(JsonConvert.SerializeObject(bpmCalculationParametersRoot));

            try
            {

                var postAndOptimizeHttpResponse =
                    bpmOptimizerApi.PostAndOptimizeWithHttpInfo(bPMOptimizationParametersRoot: bpmCalculationParametersRoot);

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
                            var pollingResponse = bpmOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
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

                        var getResultResponse = bpmOptimizerApi.GetOptimizationResultWithHttpInfo(optimizationId);
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