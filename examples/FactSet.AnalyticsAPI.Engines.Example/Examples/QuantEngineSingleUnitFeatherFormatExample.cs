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
    public class QuantEngineSingleUnitFeatherFormatExample
    {
        private static Configuration _engineApiConfiguration;
        private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = GetQuantCalculationParameters();

                var calculationApi = new QuantCalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, calculationParameters);               
                // Comment the above line and uncomment the below lines to add cache control configuration. Results are by default cached for 12 hours; Setting max-stale=300 will fetch a cached result which is at max 5 minutes older.
                //var cacheControl = "max-stale=300";
                //var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(cacheControl, calculationParameters);

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
                        OutputResult(resultResponse.Data, "output-data");

                        var infoResponse = calculationApi.GetCalculationUnitInfoByIdWithHttpInfo(calculationId, calculation.Key);
                        OutputResult(infoResponse.Data, "info-data");
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
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Reason : {e.ErrorContent}");
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


        private static QuantCalculationParametersRoot GetQuantCalculationParameters()
        {
            var universe = new OneOfQuantUniverse(new QuantScreeningExpressionUniverse(universeExpr: "ISON_DOW", universeType: QuantScreeningExpressionUniverse.UniverseTypeEnum.Equity, securityExpr: "TICKER", source: QuantScreeningExpressionUniverse.SourceEnum.ScreeningExpressionUniverse));
            var dates = new OneOfQuantDates(new QuantFdsDate(startDate: "0", endDate: "-5D", source: QuantFdsDate.SourceEnum.FdsDate, frequency: "D", calendar: "FIVEDAY", true));
            var formulas = new List<OneOfQuantFormulas>()
            {
                new OneOfQuantFormulas(new QuantScreeningExpression(expr: "P_PRICE", name: "Price (SCR)", source: QuantScreeningExpression.SourceEnum.ScreeningExpression)),
                new OneOfQuantFormulas(new QuantFqlExpression(expr: "P_PRICE", name: "Price (SCR)", source: QuantFqlExpression.SourceEnum.FqlExpression))
            };

            var quantCalculation = new QuantCalculationParameters(universe: universe, dates: dates, formulas: formulas);

            var quantCalculationsMeta = new QuantCalculationMeta(format: QuantCalculationMeta.FormatEnum.Feather);

            var calculationParameters = new QuantCalculationParametersRoot
            {
                Data = new Dictionary<string, QuantCalculationParameters> { { "1", quantCalculation } },
                Meta = quantCalculationsMeta
            };

            return calculationParameters;
        }

        private static void OutputResult(Stream result, string fileName)
        {
            Console.WriteLine("Calculation Result");

            File.WriteAllBytes($"{fileName}.ftr", ((MemoryStream)result).ToArray());

            Console.WriteLine($"Calculation output saved to {fileName}.ftr");
        }
    }
}
