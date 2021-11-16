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
    public class AfiOptimizerExample
    {
        private static Configuration _apiConfiguration;
        //max-stale=0 will be a fresh adhoc run and the max-stale value is in seconds.
        //Results are by default cached for 12 hours; Setting max-stale=300 will fetch a cached result which is 5 minutes older.
         private static string CacheControl = "max-stale=0";

        public static void Main(string[] args)
        {
            try
            {
                const string strategyId = "CLIENT:/Analytics_api/AFIAPISIMPLE";
                var afiStrategy = new AFIOptimizerStrategy(null, strategyId);
                var tradesList = new OptimizerTradesList(OptimizerTradesList.IdentifierTypeEnum.Asset, false);
                var outputTypes = new OptimizerOutputTypes(tradesList);

                var afiCalculationParameters =
                    new AFIOptimizationParameters(strategy: afiStrategy, outputTypes: outputTypes);
                var afiCalculationParameterRoot = new AFIOptimizationParametersRoot(afiCalculationParameters);

                var afiOptimizerApi = new AFIOptimizerApi(GetApiConfiguration());

                var calculationResponse =
                    afiOptimizerApi.PostAndOptimizeWithHttpInfo(null, CacheControl, afiCalculationParameterRoot);

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
                            afiOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
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
                                    afiOptimizerApi.GetOptimizationStatusByIdWithHttpInfo(optimizationId);
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
                BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST"),
                Username = Environment.GetEnvironmentVariable("FACTSET_USERNAME"),
                Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD")
        };
            
            // Uncomment below lines for adding the proxy configuration
            //System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
            //webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //_apiConfiguration.Proxy = webProxy;

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