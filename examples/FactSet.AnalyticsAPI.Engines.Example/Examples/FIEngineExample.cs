using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach.Extensions;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class FIEngineExample
    {
        private static Configuration _apiConfiguration;
        private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");

        public static void Main(string[] args)
        {
            try
            {
                var fiSecurities = new List<FISecurity>
                {
                    new FISecurity(
                        calcFromMethod: "Price",
                        calcFromValue: 10000.0,
                        face: 10000.0,
                        symbol: "912828ZG8",
                        settlement: "20201202",
                        discountCurve: "UST"
                        ),
                    new FISecurity(
                        calcFromMethod: "Price",
                        calcFromValue: 101.138,
                        face: 200000.0,
                        symbol: "US037833AR12",
                        settlement: "20201203",
                        discountCurve: "UST"
                        )
                };

                var fiCalculations = new List<string>
                {
                    "Security Type",
                    "Security Name",
                    "Run Status",
                    "Elapse Time (seconds)",
                    "Calc From Method",
                    "Option Pricing Model",
                    "Yield Curve Date",
                    "Settlement Date",
                    "Discount Curve",
                    "Price",
                    "Yield to No Call",
                    "OAS",
                    "Effective Duration",
                    "Effective Convexity"
                };

                var ratePath = new FIMarketEnvironment
                {
                    RatePath = FIMarketEnvironment.RatePathEnum.FLATFORWARD
                };

                var fiJobSettings = new FIJobSettings("20201201", marketEnvironment: ratePath);

                var fiCalculationParameters = new FICalculationParameters(fiSecurities, fiCalculations, fiJobSettings);
                var fiCalculationParameterseRoot = new FICalculationParametersRoot(data: fiCalculationParameters);


                var fiCalculationsApi = new FICalculationsApi(GetApiConfiguration());

                var calculationResponse = fiCalculationsApi.PostAndCalculateWithHttpInfo(null, null, fiCalculationParameterseRoot);
                // Comment the above line and uncomment the below lines to add cache control configuration. Results are by default cached for 12 hours; Setting max-stale=300 will fetch a cached result which is at max 5 minutes older.
                //var cacheControl = "max-stale=300";
                //var calculationResponse = fiCalculationsApi.PostAndCalculateWithHttpInfo(null, cacheControl, fiCalculationParameterseRoot);

                switch (calculationResponse.StatusCode)
                {
                    case HttpStatusCode.Created:
                        var result = (ObjectRoot) calculationResponse.Data;
                        PrintResult(result);
                        return;
                    case HttpStatusCode.Accepted:
                        var calculationStatus = (CalculationInfoRoot) calculationResponse.Data;
                        var calculationId = calculationStatus.Data.CalculationId;
                        Console.WriteLine("Calculation Id: " + calculationId);
                        var optimizationStatusResponse =
                            fiCalculationsApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
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
                                    fiCalculationsApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                            }
                            else
                            {
                                continuePolling = false;
                            }
                        }

                        if (optimizationStatusResponse.StatusCode == HttpStatusCode.Created)
                        {
                            Console.WriteLine("Calculation Id: " + calculationId + " succeeded!");
                            PrintResult((ObjectRoot)optimizationStatusResponse.Data);
                        }
                        else
                        {
                            Console.WriteLine("Calculation Id: " + calculationId + " failed!");
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

        private static void PrintResult(ObjectRoot result)
        {
            Console.WriteLine("Calculation Result");

            // converting the data to Package object
            var stachBuilder = StachExtensionFactory.GetRowOrganizedBuilder();
            var stachExtension = stachBuilder.SetPackage(result.Data).Build();
            // To convert package to 2D tables.
            var tables = stachExtension.ConvertToTable();

            Console.WriteLine(tables[0]);
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
            
            // Uncomment below lines for adding the proxy configuration
            //System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
            //webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //_apiConfiguration.Proxy = webProxy;

            return _apiConfiguration;
        }
    }
}
