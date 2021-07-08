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
    public class FIEngineExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";

        public static void Main(string[] args)
        {
            try
            {
                var fiSecurities = new List<FISecurity>
                {
                    new FISecurity("Price", 100.285, 10000.0, "912828ZG8", "20201202", "UST"),
                    new FISecurity("Price", 101.138, 200000.0, "US037833AR12", "20201203", "UST")
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

                var fiJobSettings = new FIJobSettings("20201201");

                var fiCalculationParameters = new FICalculationParameters(fiSecurities, fiCalculations, fiJobSettings);

                var fiCalculationsApi = new FICalculationsApi(GetEngineApiConfiguration());

                var runCalculationResponse = fiCalculationsApi.RunFICalculationWithHttpInfo(fiCalculationParameters);

                var calculationId = runCalculationResponse.Headers["Location"][0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                Console.WriteLine("Calculation Id: " + calculationId);
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


                foreach (var paCalculationParameters in getStatus.Data.Pa)
                {
                    if (paCalculationParameters.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        PrintResult(paCalculationParameters);
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {paCalculationParameters.Key} Failed!!!");
                        Console.WriteLine($"Error message : {paCalculationParameters.Value.Error}");
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

        private static void PrintResult(KeyValuePair<string, CalculationUnitStatus> calculation)
        {
            if (calculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
            {
                var utilityApi = new UtilityApi(GetEngineApiConfiguration());
                ApiResponse<string> resultResponse = utilityApi.GetByUrlWithHttpInfo(calculation.Value.Result);

                Console.WriteLine($"Calculation Unit Id : {calculation.Key} Succeeded!!!");
                Console.WriteLine($"Calculation Unit Id : {calculation.Key} Result");
                Console.WriteLine("/****************************************************************/");

                // converting the data to Package object
                var jpSettings = JsonParser.Settings.Default;
                var jp = new JsonParser(jpSettings.WithIgnoreUnknownFields(true));
                var package = jp.Parse<Package>(resultResponse.Data);

                // To convert package to 2D tables.
                var tables = package.ConvertToTableFormat();
                Console.WriteLine(tables[0]);

                // Uncomment the following lines to generate an Excel file
                // foreach (var table in tables)
                // {
                //     File.WriteAllText($"{Guid.NewGuid():N}.csv", table.ToString());
                // }

                Console.WriteLine("/****************************************************************/");
            }
        }

        private static void LogError<T>(ApiResponse<T> response, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Request Key: {response.Headers["X-DataDirect-Request-Key"]}");
            Console.WriteLine($"Reason: {response.Data}");
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