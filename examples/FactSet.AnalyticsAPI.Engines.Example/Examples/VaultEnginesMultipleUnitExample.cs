using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach.Extensions;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class VaultEngineMultipleUnitExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string VaultDefaultDocument = "Client:/aapi/VAULT_QA_PI_DEFAULT_LOCKED";
        private const string VaultTotalReturnsComponent = "Total Returns";
        private const string VaultPerformanceOverTimeComponentName = "Performance Over Time";
        private const string VaultComponentCategory = "Performance / Performance Relative Dates";
        private const string VaultDefaultAccount = "CLIENT:/BISAM/REPOSITORY/QA/SMALL_PORT.ACCT";
        private const string VaultStartDate = "20180101";
        private const string VaultEndDate = "20180329";
        private const string VaultFrequency = "Monthly";

        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = new VaultCalculationParametersRoot
                {
                    Data = new Dictionary<string, VaultCalculationParameters> { { "1", GetVaultCalculationParameters1() }, { "2", GetVaultCalculationParameters2() } }
                };

                var calculationApi = new VaultCalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, "max-stale=3600", calculationParameters);

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

                
                foreach (var vaultCalculation in status.Data.Units)
                {
                    if (vaultCalculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(calculationId, vaultCalculation.Key);
                        PrintResult(resultResponse.Data);
                    }
                    else
                    {
                        Console.WriteLine($"Calculation Unit Id : {vaultCalculation.Key} Failed!!!");
                        Console.WriteLine($"Error message : {vaultCalculation.Value.Errors}");
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


        private static VaultCalculationParameters GetVaultCalculationParameters1()
        {
            var componentsApi = new ComponentsApi(GetApiConfiguration());

            var componentsResponse = componentsApi.GetVaultComponents(VaultDefaultDocument);

            var vaultComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == VaultTotalReturnsComponent && component.Value.Category == VaultComponentCategory)).Key;
            Console.WriteLine($"Vault Component Id : {vaultComponentId}");
            
            var vaultAccount = new VaultIdentifier(VaultDefaultAccount);
            var vaultDates = new VaultDateParameters(VaultStartDate, VaultEndDate, VaultFrequency);

            var configurationApi = new ConfigurationsApi(GetApiConfiguration());
            var configurationResponse = configurationApi.GetVaultConfigurationsWithHttpInfo(vaultAccount.Id);
            var vaultConfigurationId = configurationResponse.Data.Data.Keys.First();

            var vaultCalculation = new VaultCalculationParameters(vaultComponentId, vaultAccount, vaultDates, vaultConfigurationId);

            return vaultCalculation;
        }
        
        private static VaultCalculationParameters GetVaultCalculationParameters2()
        {
            var componentsApi = new ComponentsApi(GetApiConfiguration());

            var componentsResponse = componentsApi.GetVaultComponents(VaultDefaultDocument);

            var vaultComponentId = componentsResponse.Data.FirstOrDefault(component => (component.Value.Name == VaultPerformanceOverTimeComponentName && component.Value.Category == VaultComponentCategory)).Key;
            Console.WriteLine($"Vault Component Id : {vaultComponentId}");
            
            var vaultAccount = new VaultIdentifier(VaultDefaultAccount);
            var vaultDates = new VaultDateParameters(VaultStartDate, VaultEndDate, VaultFrequency);

            var configurationApi = new ConfigurationsApi(GetApiConfiguration());
            var configurationResponse = configurationApi.GetVaultConfigurationsWithHttpInfo(vaultAccount.Id);
            var vaultConfigurationId = configurationResponse.Data.Data.Keys.First();

            var vaultCalculation = new VaultCalculationParameters(vaultComponentId, vaultAccount, vaultDates, vaultConfigurationId);

            return vaultCalculation;
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

        private static void LogError<T>(ApiResponse<T> response, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Request Key: {response.Headers["X-DataDirect-Request-Key"]}");
            Console.WriteLine($"Reason: {response.Data}");
        }
    }
}
