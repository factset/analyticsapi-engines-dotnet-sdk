﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Client;
using FactSet.AnalyticsAPI.Engines.v2.Model;

using FactSet.Protobuf.Stach;
using Google.Protobuf;

namespace FactSet.AnalyticsAPI.Engines.v2.Example.Examples
{
    public class PAEngineExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string PADefaultDocument = "PA_DOCUMENTS:DEFAULT";
        private const string PABenchmarkSP50 = "BENCH:SP50";
        private const string PABenchmarkR1000 = "BENCH:R.1000";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = new Calculation
                {
                    Pa = new Dictionary<string, PACalculationParameters> { { "1", GetPaCalculationParameters() } }
                };

                var calculationApi = new CalculationsApi(GetEngineApiConfiguration());

                var runCalculationResponse = calculationApi.RunCalculationWithHttpInfo(calculationParameters);

                var calculationId = runCalculationResponse.Headers["Location"][0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                ApiResponse<CalculationStatus> getStatus = null;

                while (getStatus == null || getStatus.Data.Status == CalculationStatus.StatusEnum.Queued || getStatus.Data.Status == CalculationStatus.StatusEnum.Executing)
                {
                    if (getStatus != null)
                    {
                        if (getStatus.Headers.ContainsKey("Cache-Control"))
                        {
                            var maxAge = getStatus.Headers["Cache-Control"][0];
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

                    getStatus = calculationApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                }
                Console.WriteLine("Calculation Completed");

                // Check for failed calculations
                foreach (var paCalculationParameters in getStatus.Data.Pa)
                {
                    if (paCalculationParameters.Value.Status == CalculationUnitStatus.StatusEnum.Failed)
                    {
                        Console.WriteLine($"CalculationId : {paCalculationParameters.Key} Failed!!!");
                        Console.WriteLine($"Error message : {paCalculationParameters.Value.Error}");
                    }
                }

                // Get result of successful calculations
                foreach (var paCalculationParameters in getStatus.Data.Pa)
                {
                    PrintResult(paCalculationParameters);
                }

                Console.ReadKey();
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

        private static PACalculationParameters GetPaCalculationParameters()
        {
            // Build PA Engine calculation parameters
            var componentsApi = new ComponentsApi(GetEngineApiConfiguration());

            var componentsResponse = componentsApi.GetPAComponentsWithHttpInfo(PADefaultDocument);

            if (componentsResponse.StatusCode != HttpStatusCode.OK)
            {
                LogError(componentsResponse);
                return null;
            }

            var paComponentId = componentsResponse.Data.First().Key;
            Console.WriteLine($"PA Component Id : {paComponentId}");

            var paAccountIdentifier = new PAIdentifier(PABenchmarkSP50);
            var paAccounts = new List<PAIdentifier> { paAccountIdentifier };
            var paBenchmarkIdentifier = new PAIdentifier(PABenchmarkR1000);
            var paBenchmarks = new List<PAIdentifier> { paBenchmarkIdentifier };

            var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks);

            return paCalculation;
        }

        private static void PrintResult(KeyValuePair<string, CalculationUnitStatus> calculation)
        {
            if (calculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
            {
                var utilityApi = new UtilityApi(GetEngineApiConfiguration());
                ApiResponse<string> resultResponse = utilityApi.GetByUrlWithHttpInfo(calculation.Value.Result);

                if (resultResponse.StatusCode != HttpStatusCode.OK)
                {
                    LogError(resultResponse);
                    return;
                }

                Console.WriteLine($"CalculationId : {calculation.Key} Succeeded!!!");
                Console.WriteLine($"CalculationId : {calculation.Key} Result");
                Console.WriteLine("/****************************************************************/");

                // converting the data to Package object
                var jpSettings = JsonParser.Settings.Default;
                var jp = new JsonParser(jpSettings.WithIgnoreUnknownFields(true));
                var package = jp.Parse<Package>(resultResponse.Data);

                // To convert package to 2D tables.
                var tables = package.ConvertToTableFormat();
                Console.WriteLine(tables[0]);

                // Uncomment the following line to generate an Excel file
                // package.GenerateCSV();
                Console.WriteLine("/****************************************************************/");
            }
        }

        private static void LogError<T>(ApiResponse<T> response)
        {
            Console.WriteLine("Error!!!");
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Request Key: {response.Headers["X-DataDirect-Request-Key"]}");
            Console.WriteLine($"Reason: {response.Data}");
        }
    }
}
