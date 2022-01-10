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
    public class SPAREngineMultipleUnitExample
    {
        private static Configuration _engineApiConfiguration;
        private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");
        private const string SPARDefaultDocument = "pmw_root:/spar_documents/Factset Default Document";
        private const string SPARComponentName = "Returns Table";
        private const string SPARComponentCategory = "Raw Data / Returns";
        private const string SPARBenchmark1 = "R.1000";
        private const string SPARBenchmark = "RUSSELL_P:R.2000";
        private const string SPARBenchmarkPrefix = "RUSSELL";
        private const string SPARBenchmarkReturnType = "GTR";
        private const string SPARBenchmark2 = "R.2000";
        private const string Currency = "USD";
        private const string startDate = "20180101";
        private const string endDate = "20181231";
        private const string Frequency = "Monthly";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = new SPARCalculationParametersRoot
                {
                    Data = new Dictionary<string, SPARCalculationParameters> { { "1", GetSparCalculationParameters1() }, { "2", GetSparCalculationParameters2()} }
                };

                var calculationApi = new SPARCalculationsApi(GetApiConfiguration());

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

                
                foreach (var sparCalculation in status.Data.Units)
                {
                    if (sparCalculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, sparCalculation.Key);
                        PrintResult(resultResponse.Data);
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {sparCalculation.Key} Failed!!!");
                        Console.WriteLine($"Error message : {sparCalculation.Value.Errors}");
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


        private static SPARCalculationParameters GetSparCalculationParameters1()
        {
            var componentsApi = new ComponentsApi(GetApiConfiguration());

            var componentsResponse = componentsApi.GetSPARComponents(SPARDefaultDocument);

            var sparComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == SPARComponentName && component.Value.Category == SPARComponentCategory)).Key;
            Console.WriteLine($"SPAR Component Id : {sparComponentId}");
            
            var sparAccountIdentifier = new SPARIdentifier(SPARBenchmark1, SPARBenchmarkReturnType, SPARBenchmarkPrefix);
            var sparAccounts = new List<SPARIdentifier> { sparAccountIdentifier };
            var sparBenchmarkIdentifier = new SPARIdentifier(SPARBenchmark, SPARBenchmarkReturnType, SPARBenchmarkPrefix);

            var sparCalculation = new SPARCalculationParameters(sparComponentId, sparAccounts, sparBenchmarkIdentifier);

            return sparCalculation;
        }
        
        private static SPARCalculationParameters GetSparCalculationParameters2()
        {
            var componentsApi = new ComponentsApi(GetApiConfiguration());

            var componentsResponse = componentsApi.GetSPARComponents(SPARDefaultDocument);

            var sparComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == SPARComponentName && component.Value.Category == SPARComponentCategory)).Key;
            Console.WriteLine($"SPAR Component Id : {sparComponentId}");
            
            var sparAccountIdentifier = new SPARIdentifier(SPARBenchmark2, SPARBenchmarkReturnType, SPARBenchmarkPrefix);
            var sparAccounts = new List<SPARIdentifier> { sparAccountIdentifier };
            var sparBenchmarkIdentifier = new SPARIdentifier(SPARBenchmark, SPARBenchmarkReturnType, SPARBenchmarkPrefix);
            var sparDates = new SPARDateParameters(startDate, endDate, Frequency);
            
            var sparCalculation = new SPARCalculationParameters(sparComponentId, sparAccounts, sparBenchmarkIdentifier, sparDates, Currency);

            return sparCalculation;
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