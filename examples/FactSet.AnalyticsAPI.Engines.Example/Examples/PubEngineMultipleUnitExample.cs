﻿using System;
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
    public class PubEngineMultipleUnitExample
    {
        private static Configuration _engineApiConfiguration;
        private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");
        private const string PubDocument = "Client:/AAPI/Puma Test Doc.Pub_bridge_pdf";
        private const string PubAccountId = "BENCH:SP50";
        private const string StartDate = "-1M";
        private const string EndDate = "0M";
 
        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = GetPubCalculationParameters();

                var calculationApi = new PubCalculationsApi(GetApiConfiguration());

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

                
                foreach (var calculation in status.Data.Units)
                {
                    if (calculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, calculation.Key);
                        OutputResult(resultResponse.Data, $"output-{calculation.Key}");
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


        private static PubCalculationParametersRoot GetPubCalculationParameters()
        {
            var pubAccountIdentifier = new PubIdentifier(PubAccountId);
            var pubDates = new PubDateParameters(StartDate, EndDate);

            var pubCalculation = new PubCalculationParameters(PubDocument, pubAccountIdentifier, pubDates);

            var calculationParameters = new PubCalculationParametersRoot
            {
                Data = new Dictionary<string, PubCalculationParameters> { { "1", pubCalculation }, { "2", pubCalculation } }
            };

            return calculationParameters;
        }

        private static void OutputResult(Stream result, string fileName)
        {
            Console.WriteLine("Calculation Result");

            File.WriteAllBytes($"{fileName}.pdf", ((MemoryStream)result).ToArray());

            Console.WriteLine($"Calculation output saved to {fileName}.pdf");
        }
    }
}
