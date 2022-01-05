using System;
using System.Linq;
using System.Net;
using System.Threading;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    [TestClass]
    public class AxpCalculationsApiTests
    {
        private AXPOptimizerApi axpOptimizerApi;

        [TestInitialize]
        public void Init()
        {
            axpOptimizerApi = new AXPOptimizerApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void OptimizerWorkflow_Should_Succeed_When_GivenValidInputs()
        {
            const string strategyId = "Client:/Optimizer/TAXTEST";
            const string accountId = "BENCH:SP50";
            const string riskModelDate = "09/01/2020";
            const string backtestDate = "09/01/2020";
            var axpStrategy = new AxiomaEquityOptimizerStrategy(null, strategyId);
            var axpAccount = new OptimizerAccount(accountId);
            var optimization = new Optimization(riskModelDate, backtestDate);
            var tradesList = new OptimizerTradesList(OptimizerTradesList.IdentifierTypeEnum.SedolChk, false);
            var outputTypes = new OptimizerOutputTypes(tradesList);

            var axpCalculationParameters = new AxiomaEquityOptimizationParameters(axpStrategy, axpAccount, optimization, outputTypes);
            var axpCalculationParameterRoot = new AxiomaEquityOptimizationParametersRoot(axpCalculationParameters);

            var postAndOptimizeHttpResponse = axpOptimizerApi.PostAndOptimizeWithHttpInfo(axiomaEquityOptimizationParametersRoot : axpCalculationParameterRoot);

            postAndOptimizeHttpResponse.StatusCode
                .Should()
                .Match<HttpStatusCode>(c => c == HttpStatusCode.Created || c == HttpStatusCode.Accepted);

            switch (postAndOptimizeHttpResponse.StatusCode)
            {
                case HttpStatusCode.Accepted:
                    var optimizationId = postAndOptimizeHttpResponse.Headers["X-Factset-Api-Calculation-Id"].First();
                    bool shouldPoll;
                    do
                    {
                        var pollingResponse = axpOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
                        pollingResponse.StatusCode
                            .Should()
                            .Match<HttpStatusCode>(c => c == HttpStatusCode.Created || c == HttpStatusCode.Accepted);

                        if (pollingResponse.StatusCode == HttpStatusCode.Created)
                            break;

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

                    var getResultResponse = axpOptimizerApi.GetOptimizationResultWithHttpInfo(optimizationId);
                    getResultResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                    getResultResponse.Data.Should().NotBeNull();
                    break;
                case HttpStatusCode.Created:
                    break;
            }
        }
    }
}