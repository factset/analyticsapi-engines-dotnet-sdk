using System;
using System.Net;
using System.Threading;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;
using FactSet.Protobuf.Stach.Extensions;
using Newtonsoft.Json.Linq;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class AxpOptimizerExample
    {
        private static Configuration _apiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private static readonly string UserName = Environment.GetEnvironmentVariable("ANALYTICS_API_USERNAME_SERIAL");
        private static readonly string Password = Environment.GetEnvironmentVariable("ANALYTICS_API_PASSWORD");

        public static void Main(string[] args)
        {
            try
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

                var axpCalculationParameters =
                    new AxiomaEquityOptimizationParameters(axpStrategy, axpAccount, optimization, outputTypes);
                var axpCalculationParameterRoot = new AxiomaEquityOptimizationParametersRoot(axpCalculationParameters);

                var axpOptimizerApi = new AXPOptimizerApi(GetApiConfiguration());

                var calculationResponse =
                    axpOptimizerApi.PostAndOptimizeWithHttpInfo(null, "max-stale=0", axpCalculationParameterRoot);

                switch (calculationResponse.StatusCode)
                {
                    case HttpStatusCode.Created:
                        var result = (ObjectRoot) calculationResponse.Data;
                        PrintResult(result);
                        return;
                    case HttpStatusCode.Accepted:
                        var calculationStatus = (CalculationInfoRoot) calculationResponse.Data;
                        var optimizationId = calculationStatus.Data.CalculationId;
                        Console.WriteLine("Optimization Id: " + optimizationId);
                        var optimizationStatusResponse =
                            axpOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
                        var continuePolling = optimizationStatusResponse.StatusCode == HttpStatusCode.Accepted;
                        while (continuePolling)
                        {
                            if (optimizationStatusResponse.StatusCode == HttpStatusCode.Accepted)
                            {
                                if (optimizationStatusResponse.Headers.ContainsKey("Cache-Control"))
                                {
                                    var maxAge = optimizationStatusResponse.Headers["Cache-Control"][0];
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

                                optimizationStatusResponse =
                                    axpOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
                            }
                            else
                            {
                                continuePolling = false;
                            }
                        }

                        if (optimizationStatusResponse.StatusCode == HttpStatusCode.Created)
                        {
                            Console.WriteLine("Optimization Id: " + optimizationId + " succeeded!");
                            PrintResult((ObjectRoot)optimizationStatusResponse.Data);
                        }
                        else
                        {
                            Console.WriteLine("Optimization Id: " + optimizationId + " failed!");
                            Console.WriteLine("Error message: " + optimizationStatusResponse.ErrorText);
                        }

                        break;
                }
            }
            catch (ApiException e)
            {
                Console.WriteLine($"Status Code: {e.ErrorCode}");
                Console.WriteLine($"Reason : {e.Message}");
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static Configuration GetApiConfiguration()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (_apiConfiguration != null)
            {
                return _apiConfiguration;
            }

            _apiConfiguration = new Configuration
            {
                BasePath = BasePath,
                Username = UserName,
                Password = Password
            };

            return _apiConfiguration;
        }

        private static void PrintResult(ObjectRoot result)
        {
            Console.WriteLine("Calculation Result");

            // converting the data to Package object
            var stachBuilder = StachExtensionFactory.GetRowOrganizedBuilder();
            var stachExtension = stachBuilder.AddTable("tradesTable", JObject.FromObject(result.Data)["trades"]).Build();
            //var stachExtension = stachBuilder.AddTable("optimalsTable", JObject.FromObject(result.Data)["optimal"]).Build();
            // To convert package to 2D tables.
            var tables = stachExtension.ConvertToTable();

            Console.WriteLine(tables[0]);
        }
    }
}