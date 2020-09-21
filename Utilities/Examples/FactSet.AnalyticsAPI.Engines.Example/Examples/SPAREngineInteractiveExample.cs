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
    public class SPAREngineInteractiveExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string SPARDefaultDocument = "pmw_root:/spar_documents/Factset Default Document";
        private const string SPARComponentName = "Returns Table";
        private const string SPARComponentCategory = "Raw Data / Returns";
        private const string SPARBenchmarkR1000 = "R.1000";
        private const string SPARBenchmarkRussellPr2000 = "RUSSELL_P:R.2000";
        private const string SPARBenchmarkRussellPrefix = "RUSSELL";
        private const string SPARBenchmarkRussellReturnType = "GTR";

        public static void Main(string[] args)
        {
            try
            {
                // Build SPAR Engine calculation parameters
                var componentsApi = new ComponentsApi(GetEngineApiConfiguration());

                var componentsResponse = componentsApi.GetSPARComponentsWithHttpInfo(SPARDefaultDocument);

                var sparComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == SPARComponentName && component.Value.Category == SPARComponentCategory)).Key;
                Console.WriteLine($"SPAR Component Id : {sparComponentId}");
                var sparAccountIdentifier = new SPARIdentifier(SPARBenchmarkR1000, SPARBenchmarkRussellReturnType, SPARBenchmarkRussellPrefix);
                var sparAccounts = new List<SPARIdentifier> { sparAccountIdentifier };
                var sparBenchmarkIdentifier = new SPARIdentifier(SPARBenchmarkRussellPr2000, SPARBenchmarkRussellReturnType, SPARBenchmarkRussellPrefix);

                var sparCalculation = new SPARCalculationParameters(sparComponentId, sparAccounts, sparBenchmarkIdentifier);

                var calculationApi = new SPARCalculationsApi(GetEngineApiConfiguration());

                var runCalculationResponse = calculationApi.RunSPARCalculationWithHttpInfo(sparCalculation);

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

                    runCalculationResponse = calculationApi.GetSPARCalculationByIdWithHttpInfo(calculationId);
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