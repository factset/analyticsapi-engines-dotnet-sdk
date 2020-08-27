using System;
using System.IO;
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
    public class VaultEngineExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string VaultDefaultDocument = "PA3_DOCUMENTS:DEFAULT";
        private const string VaultComponentName = "Weights";
        private const string VaultComponentCategory = "General / Positioning";
        private const string VaultDefaultAccount = "Client:/analytics/data/US_MID_CAP_CORE.ACTM";
        private const string VaultStartDate = "FIRST_REPOSITORY";
        private const string VaultEndDate = "LAST_REPOSITORY";
        private const string VaultFrequency = "Monthly";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = new Calculation
                {
                    Vault = new Dictionary<string, VaultCalculationParameters> { { "1", GetVaultCalculationParameters() } }
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

                
                foreach (var vaultCalculationParameters in getStatus.Data.Vault)
                {
                    if (vaultCalculationParameters.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        PrintResult(vaultCalculationParameters);
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {vaultCalculationParameters.Key} Failed!!!");
                        Console.WriteLine($"Error message : {vaultCalculationParameters.Value.Error}");
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

        private static VaultCalculationParameters GetVaultCalculationParameters()
        {
            // Build Vault Engine calculation parameters
            var componentsApi = new ComponentsApi(GetEngineApiConfiguration());

            var componentsResponse = componentsApi.GetVaultComponentsWithHttpInfo(VaultDefaultDocument);

            var vaultComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == VaultComponentName && component.Value.Category == VaultComponentCategory)).Key;
            Console.WriteLine($"Vault Component Id : {vaultComponentId}");

            var vaultAccount = new VaultIdentifier(VaultDefaultAccount);
            var vaultDates = new VaultDateParameters(VaultStartDate, VaultEndDate, VaultFrequency);

            var configurationApi = new ConfigurationsApi(GetEngineApiConfiguration());

            var configurationResponse = configurationApi.GetVaultConfigurationsWithHttpInfo(vaultAccount.Id);
            var vaultConfiguration = configurationResponse.Data.First().Key;

            var vaultCalculation = new VaultCalculationParameters(vaultComponentId, vaultAccount, vaultDates, vaultConfiguration);

            return vaultCalculation;
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
            Console.WriteLine("Status Code: " + response.StatusCode);
            Console.WriteLine("Request Key: " + response.Headers["X-DataDirect-Request-Key"]);
            Console.WriteLine($"Reason: {response.Data}");
        }
    }
}
