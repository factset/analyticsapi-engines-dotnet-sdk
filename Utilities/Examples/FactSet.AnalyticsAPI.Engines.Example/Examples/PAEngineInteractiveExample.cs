using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach;
using Google.Protobuf;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class PAEngineInteractiveExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string PADefaultDocument = "PA_DOCUMENTS:DEFAULT";
        private const string PAComponentName = "Weights";
        private const string PAComponentCategory = "Weights / Exposures";
        private const string PABenchmarkSP50 = "BENCH:SP50";
        private const string PABenchmarkR1000 = "BENCH:R.1000";

        public static void Main(string[] args)
        {
            try
            {
                var componentsApi = new ComponentsApi(GetEngineApiConfiguration());

                var componentsResponse = componentsApi.GetPAComponentsWithHttpInfo(PADefaultDocument);

                var paComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == PAComponentName && component.Value.Category == PAComponentCategory)).Key;
                Console.WriteLine($"PA Component Id : {paComponentId}");

                var paAccountIdentifier = new PAIdentifier(PABenchmarkSP50);
                var paAccounts = new List<PAIdentifier> { paAccountIdentifier };
                var paBenchmarkIdentifier = new PAIdentifier(PABenchmarkR1000);
                var paBenchmarks = new List<PAIdentifier> { paBenchmarkIdentifier };

                var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks);

                var calculationApi = new PACalculationsApi(GetEngineApiConfiguration());

                var runCalculationResponse = calculationApi.RunPACalculationWithHttpInfo(paCalculation);

                var calculationId = string.Empty;

                while (runCalculationResponse.StatusCode == HttpStatusCode.Accepted)
                {
                    if (string.IsNullOrWhiteSpace(calculationId))
                    {
                        runCalculationResponse.Headers.TryGetValue("Location", out var location);
                        calculationId = location?[0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    }

                    if (runCalculationResponse.Headers.ContainsKey("Cache-Control") &&
                        runCalculationResponse.Headers["Cache-Control"][0] is var maxAge &&
                        !string.IsNullOrWhiteSpace(maxAge))
                    {
                        var age = int.Parse(maxAge.Replace("max-age=", ""));
                        Console.WriteLine($"Sleeping for {age} seconds");
                        Thread.Sleep(age * 1000);
                    }
                    else
                    {
                        Console.WriteLine("Sleeping for 2 seconds");
                        // Sleep for at least 2 seconds.
                        Thread.Sleep(2000);
                    }

                    runCalculationResponse = calculationApi.GetPACalculationByIdWithHttpInfo(calculationId);
                }

                var jpSettings = JsonParser.Settings.Default;
                var jp = new JsonParser(jpSettings.WithIgnoreUnknownFields(true));
                var package = jp.Parse<Package>(runCalculationResponse.Data.ToString());

                Console.WriteLine($"Calculation Id : {calculationId} Succeeded!!!");
                Console.WriteLine("/****************************************************************/");

                // To convert package to 2D tables.
                var tables = package.ConvertToTableFormat();
                Console.WriteLine(tables[0]);

                Console.WriteLine("/****************************************************************/");

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

        private static Configuration GetEngineApiConfiguration()
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
    }
}