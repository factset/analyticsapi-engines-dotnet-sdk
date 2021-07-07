using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach;
using FactSet.Protobuf.Stach.Extensions;
using FactSet.Protobuf.Stach.Extensions.Models;
using Google.Protobuf;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class PAEngineSingleUnitExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string PADefaultDocument = "PA_DOCUMENTS:DEFAULT";
        private const string ComponentName = "Weights";
        private const string ComponentCategory = "Weights / Exposures";
        private const string ColumnName = "Port. Ending Weight";
        private const string ColumnCategory = "Portfolio/Position Data";
        private const string ColumnDirectory = "Factset";
        private const string GroupName = "Economic Sector - FactSet";
        private const string GroupCategory = "FactSet";
        private const string GroupDirectory = "Factset";
        private const string BenchmarkSP50 = "BENCH:SP50";
        private const string BenchmarkR1000 = "BENCH:R.1000";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = new PACalculationParametersRoot
                {
                    Data = new Dictionary<string, PACalculationParameters> { { "1", GetPaCalculationParameters() } }
                };

                var calculationApi = new PACalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, "max-stale=3600", calculationParameters);

                if (calculationResponse.StatusCode == HttpStatusCode.Created)
                {
                    ObjectRoot result = (ObjectRoot)calculationResponse.Data;
                    PrintResult(result);
                    return;
                }

                CalculationStatusRoot status = (CalculationStatusRoot)calculationResponse.Data;
                var calculationId = status.Data.Calculationid;
                Console.WriteLine("Calculation Id: " + calculationId);
                ApiResponse<CalculationStatusRoot> getResponse = null;

                while (status.Data.Status == CalculationStatus.StatusEnum.Queued || status.Data.Status == CalculationStatus.StatusEnum.Executing)
                {
                    if (getResponse != null)
                    {
                        if (getResponse.Headers.ContainsKey("Cache-Control"))
                        {
                            var maxAge = getResponse.Headers["Cache-Control"][0];
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

                    getResponse = calculationApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                    status = getResponse.Data;
                }
                Console.WriteLine("Calculation Completed");

                
                foreach (var paCalculation in status.Data.Units)
                {
                    if (paCalculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, paCalculation.Key);
                        PrintResult(resultResponse.Data);
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {paCalculation.Key} Failed!!!");
                        Console.WriteLine($"Error message : {paCalculation.Value.Errors}");
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

            return _engineApiConfiguration;
        }


        private static PACalculationParameters GetPaCalculationParameters()
        {
            var componentsApi = new ComponentsApi(GetApiConfiguration());

            var componentsResponse = componentsApi.GetPAComponents(PADefaultDocument);

            var paComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == ComponentName && component.Value.Category == ComponentCategory)).Key;
            Console.WriteLine($"PA Component Id : {paComponentId}");

            var paAccountIdentifier = new PAIdentifier(BenchmarkSP50);
            var paAccounts = new List<PAIdentifier> { paAccountIdentifier };
            var paBenchmarkIdentifier = new PAIdentifier(BenchmarkR1000);
            var paBenchmarks = new List<PAIdentifier> { paBenchmarkIdentifier };

            var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks);

            return paCalculation;
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

        private static void LogError<T>(ApiResponse<T> response, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Request Key: {response.Headers["X-DataDirect-Request-Key"]}");
            Console.WriteLine($"Reason: {response.Data}");
        }
    }
}
