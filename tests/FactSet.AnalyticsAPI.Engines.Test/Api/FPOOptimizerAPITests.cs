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
    public class FpoCalculationsApiTests
    {
        private FPOOptimizerApi fpoOptimizerApi;

        [TestInitialize]
        public void Init()
        {
            fpoOptimizerApi = new FPOOptimizerApi(CommonFunctions.BuildConfiguration());
        }

        [TestMethod]
        public void FPOOptimizerWorkflow_Should_Succeed_When_GivenValidInputs()
        {
            const string strategyId = "Client:/analytics_api/dbui_simple_strategy";
            const string accountId = "CLIENT:/FPO/1K_MAC_AMZN_AAPL.ACCT";
            const string riskModelDate = "0M";
            const string backtestDate = "0M";
            var fpoPaDoc = new PaDoc("CLIENT:/FPO/FPO_MASTER");
            var fpoStrategy = new FPOOptimizerStrategy(null, strategyId);
            var fpoAccount = new FPOAccount(fpoPaDoc,accountId);
            var optimization = new Optimization(riskModelDate, backtestDate);
            var tradesList = new OptimizerTradesList(OptimizerTradesList.IdentifierTypeEnum.SedolChk, false);
            var outputTypes = new OptimizerOutputTypes(tradesList);

            var fpoCalculationParameters = new FPOOptimizationParameters(fpoAccount, fpoStrategy,  optimization, outputTypes);
            var fpoCalculationParameterRoot = new FPOOptimizationParametersRoot(fpoCalculationParameters);

            var postAndOptimizeHttpResponse = fpoOptimizerApi.PostAndOptimizeWithHttpInfo(null,null,fpoCalculationParameterRoot);

            postAndOptimizeHttpResponse.StatusCode.Should().Match<HttpStatusCode>(c => c == HttpStatusCode.Created || c == HttpStatusCode.Accepted);

            switch (postAndOptimizeHttpResponse.StatusCode)
            {
                case HttpStatusCode.Accepted:
                    var optimizationId = postAndOptimizeHttpResponse.Headers["X-Factset-Api-Calculation-Id"].First();
                    bool shouldPoll;
                    do
                    {
                        var pollingResponse = fpoOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
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

                    var getResultResponse = fpoOptimizerApi.GetOptimizationResultWithHttpInfo(optimizationId);
                    getResultResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                    getResultResponse.Data.Should().NotBeNull();
                    break;
                case HttpStatusCode.Created:
                    break;
            }
        }
    }
}

        