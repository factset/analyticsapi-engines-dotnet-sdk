using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach.Extensions;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class PAEngineMultipleUnitExample
    {
        private static Configuration _engineApiConfiguration;
        private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");
        private const string PADocument = "PA_DOCUMENTS:DEFAULT";
        private const string ComponentName = "Weights";
        private const string ComponentCategory = "Weights / Exposures";
        private const string Portfolio= "BENCH:SP50";
        private const string Benchmark = "BENCH:R.1000";
        private const string PricingSourceName = "MSCI - Gross";
        private const string PricingSourceCategory = "MSCI";
        private const string PricingSourceDirectory = "Equity";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = GetPaCalculationParameters();

                var calculationApi = new PACalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, null, calculationParameters);
                // Comment the above line and uncomment the below lines to add cache control configuration. Results are by default cached for 12 hours; Setting max-stale=300 will fetch a cached result which is at max 5 minutes older.
                //var cacheControl = "max-stale=300";
                //var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, cacheControl, calculationParameters);

                CalculationStatusRoot status = (CalculationStatusRoot)calculationResponse.Data;
                var calculationId = status.Data.Calculationid;
                Console.WriteLine("Calculation Id: " + calculationId);

                ApiResponse<CalculationStatusRoot> getStatusResponse = null;

                while (status.Data.Status == CalculationStatus.StatusEnum.Queued || status.Data.Status == CalculationStatus.StatusEnum.Executing)
                {
                    if (getStatusResponse != null)
                    {
                        if (getStatusResponse.Headers.ContainsKey("Cache-Control"))
                        {
                            var maxAge = getStatusResponse.Headers["Cache-Control"][0];
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
                    }

                    getStatusResponse = calculationApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                    status = getStatusResponse.Data;
                }
                Console.WriteLine("Calculation Completed");

                
                foreach (var calculation in status.Data.Units)
                {
                    if (calculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, calculation.Key);
                        PrintResult(resultResponse.Data);
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {calculation.Key} Failed!!!");
                        Console.WriteLine($"Error message : {calculation.Value.Errors?.FirstOrDefault()?.Detail}");
                    }
                }

                Console.ReadKey();
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
            if (_engineApiConfiguration != null)
            {
                return _engineApiConfiguration;
            }

            _engineApiConfiguration = new Configuration
            {
                BasePath = BasePath,
                Username = UserName,
                Password = Password
            };
            
            // Uncomment below lines for adding the proxy configuration
            //System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
            //webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //_engineApiConfiguration.Proxy = webProxy;

            return _engineApiConfiguration;
        }


        private static PACalculationParametersRoot GetPaCalculationParameters()
        {
            var componentsApi = new ComponentsApi(GetApiConfiguration());

            var componentsResponse = componentsApi.GetPAComponents(PADocument);

            var paComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == ComponentName && component.Value.Category == ComponentCategory)).Key;
            Console.WriteLine($"PA Component Id : {paComponentId}");

            var pricingSourcesApi = new PricingSourcesApi(GetApiConfiguration());

            var pricingSourcesResponse = pricingSourcesApi.GetPAPricingSources(PricingSourceName, PricingSourceCategory, PricingSourceDirectory);

            var paPricingSourceId = pricingSourcesResponse.Data.FirstOrDefault(pricingSource => (pricingSource.Value.Name == PricingSourceName && pricingSource.Value.Category == PricingSourceCategory && pricingSource.Value.Directory == PricingSourceDirectory)).Key;
            Console.WriteLine($"PA PricingSource Id : {paPricingSourceId}");

            var paAccountIdentifier = new PAIdentifier(Portfolio);
            var paAccounts = new List<PAIdentifier> { paAccountIdentifier };
            var paBenchmarkIdentifier = new PAIdentifier(Benchmark);
            var paBenchmarks = new List<PAIdentifier> { paBenchmarkIdentifier };

            var paPortfolioPricingSources = new List<PACalculationPricingSource> { new PACalculationPricingSource(id: paPricingSourceId) };

            var paCalculationDataSources = new PACalculationDataSources(portfoliopricingsources: paPortfolioPricingSources, useportfoliopricingsourcesforbenchmark: true);

            var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks, datasources: paCalculationDataSources);

            var calculationParameters = new PACalculationParametersRoot
            {
                Data = new Dictionary<string, PACalculationParameters> {
                    { "1", paCalculation },
                    { "2", paCalculation }
                }
            };

            return calculationParameters;
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
    }
}
