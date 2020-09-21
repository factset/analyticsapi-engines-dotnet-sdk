using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class PubEngineExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string PubDefaultDocument = "Client:/AAPI/Puma Test Doc.Pub_bridge_pdf";
        private const string PubAccount = "BENCH:SP50";
        private const string PubStartDate = "-1M";
        private const string PubEndDate = "0M";

        public static void Main()
        {
            try
            {
                var calculationParameters = new Calculation
                {
                    Pub = new Dictionary<string, PubCalculationParameters> { { "1", GetPubCalculationParameters() } }
                };

                var calculationApi = new CalculationsApi(GetEngineApiConfiguration());

                var runCalculationResponse = calculationApi.RunCalculationWithHttpInfo(calculationParameters);

                var calculationId = runCalculationResponse.Headers["Location"][0].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                Console.WriteLine("Calculation Id: " + calculationId);
                ApiResponse<CalculationStatus> getStatus = null;

                while (getStatus == null || getStatus.Data.Status == CalculationStatus.StatusEnum.Queued || getStatus.Data.Status == CalculationStatus.StatusEnum.Executing)
                {
                    if (getStatus != null)
                    {
                        if (getStatus.Headers.ContainsKey("Cache-Control") &&
                            getStatus.Headers["Cache-Control"][0] is var maxAge &&
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
                    }

                    getStatus = calculationApi.GetCalculationStatusByIdWithHttpInfo(calculationId);
                }
                Console.WriteLine("Calculation Completed");


                foreach (var parameters in getStatus.Data.Pub)
                {
                    if (parameters.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var utilityApi = new UtilityApi(GetEngineApiConfiguration());
                        ApiResponse<string> resultResponse = utilityApi.GetByUrlWithHttpInfo(parameters.Value.Result);

                        Console.WriteLine($"Calculation Unit Id : {parameters.Key} Succeeded!!!");
                        Console.WriteLine($"Calculation Unit Id : {parameters.Key} Result");
                        Console.WriteLine("/****************************************************************/");

                        File.WriteAllBytes("output.pdf", resultResponse.RawBytes);

                        Console.WriteLine("Calculation output saved to output.pdf");

                        Console.WriteLine("/****************************************************************/");
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {parameters.Key} Failed!!!");
                        Console.WriteLine($"Error message : {parameters.Value.Error}");
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

        private static PubCalculationParameters GetPubCalculationParameters()
        {
            var pubAccountIdentifier = new PubIdentifier(PubAccount);
            var pubDateParameters = new PubDateParameters(PubStartDate, PubEndDate);

            return new PubCalculationParameters(PubDefaultDocument, pubAccountIdentifier,
                pubDateParameters);
        }
    }
}