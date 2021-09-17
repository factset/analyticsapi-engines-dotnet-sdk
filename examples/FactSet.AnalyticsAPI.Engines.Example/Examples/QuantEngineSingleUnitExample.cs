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
        private const string UserName = "FDSQAR_C-1021374";
        private const string Password = "Iyc1x5RFBKeWp7dKFVWKM5i3PIuVR8s8laUiFQpp";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = GetQuantCalculationParameters();

                var calculationApi = new QuantCalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo("max-stale=0", calculationParameters);

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
                        var result = JsonConvert.DeserializeObject<ObjectRoot>(resultResponse.RawContent);
                        ConvertToStachPackage(result);
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


        private static QuantCalculationParametersRoot GetQuantCalculationParameters()
        {
            var screeningExpressionUniverse = new QuantScreeningExpressionUniverse("ISON_DOW",
                QuantScreeningExpressionUniverse.UniverseTypeEnum.Equity, "TICKER",
                QuantScreeningExpressionUniverse.SourceEnum.ScreeningExpressionUniverse);
            var fdsDate = new QuantFdsDate("0", "-5D", QuantFdsDate.SourceEnum.FdsDate, "D", "FIVEDAY");
            var screeningExpression = new QuantScreeningExpression("P_PRICE", "Price (SCR)", QuantScreeningExpression.SourceEnum.ScreeningExpression);
            var fqlExpression = new QuantFqlExpression("P_PRICE", "Price (SCR)", QuantFqlExpression.SourceEnum.FqlExpression);

            var quantCalculation = new QuantCalculationParameters(screeningExpressionUniverse, fdsDate,
                new List<object> {screeningExpression, fqlExpression});

            var calculationParameters = new QuantCalculationParametersRoot
            {
                Data = new Dictionary<string, QuantCalculationParameters> { { "1", quantCalculation } }
            };

            return calculationParameters;
        }

        private static void ConvertToStachPackage(ObjectRoot result)
        {
            Console.WriteLine("Calculation Result");

            // converting the data to Package object
            var stachBuilder = StachExtensionFactory.GetRowOrganizedBuilder();
            var package = stachBuilder.SetPackage(result.Data).GetPackage();
        }
    }
}
