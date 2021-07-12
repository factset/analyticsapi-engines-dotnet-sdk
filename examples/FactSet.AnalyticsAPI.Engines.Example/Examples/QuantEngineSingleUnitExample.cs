using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;
using FactSet.Protobuf.Stach.Extensions;
using Newtonsoft.Json;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class QuantEngineSingleUnitExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = GetQuantCalculationParameters();

                var calculationApi = new QuantCalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo("max-stale=0", calculationParameters);

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


                foreach (var calculation in status.Data.Units)
                {
                    if (calculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, calculation.Key);
                        var result = JsonConvert.DeserializeObject<ObjectRoot>(resultResponse.Data.ToString());
                        PrintResult(result);
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

            return _engineApiConfiguration;
        }


        private static QuantCalculationParametersRoot GetQuantCalculationParameters()
        {
            var screeningExpressionUniverse = new QuantScreeningExpressionUniverse("ISON_DOW", QuantScreeningExpressionUniverse.UniverseTypeEnum.Equity, "TICKER");
            var fdsDate = new QuantFdsDate("0", "-5D", "D", "FIVEDAY");
            var screeningExpression = new List<QuantScreeningExpression>()
            {
                new QuantScreeningExpression("P_PRICE", "Price (SCR)")
            };
            var fqlExpression = new List<QuantFqlExpression>()
            {
                new QuantFqlExpression("P_PRICE", "Price (SCR)")
            };

            var quantCalculation = new QuantCalculationParameters(screeningExpressionUniverse: screeningExpressionUniverse, fdsDate: fdsDate, screeningExpression: screeningExpression, fqlExpression: fqlExpression);

            var calculationParameters = new QuantCalculationParametersRoot
            {
                Data = new Dictionary<string, QuantCalculationParameters> { { "1", quantCalculation } }
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
