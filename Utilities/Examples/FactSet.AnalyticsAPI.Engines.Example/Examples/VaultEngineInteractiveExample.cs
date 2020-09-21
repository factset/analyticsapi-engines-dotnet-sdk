using System;
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
    public class VaultEngineInteractiveExample
    {
        private static Configuration _engineApiConfiguration;
        private const string BasePath = "https://api.factset.com";
        private const string UserName = "<username-serial>";
        private const string Password = "<apiKey>";
        private const string VaultDefaultDocument = "Client:/aapi/VAULT_QA_PI_DEFAULT_LOCKED";
        private const string VaultComponentName = "Average\r\nWeight";
        private const string VaultComponentCategory = "Performance / 4 Tiles Calculate";
        private const string VaultDefaultAccount = "CLIENT:/BISAM/REPOSITORY/QA/SMALL_PORT.ACCT";
        private const string VaultStartDate = "20180101";
        private const string VaultEndDate = "20180331";
        private const string VaultFrequency = "Monthly";

        public static void Main(string[] args)
        {
            try
            {
                // Build Vault Engine calculation parameters
                var componentsApi = new ComponentsApi(GetEngineApiConfiguration());

                var componentsResponse = componentsApi.GetVaultComponentsWithHttpInfo(VaultDefaultDocument);

                var vaultComponentId = componentsResponse.Data.FirstOrDefault(component =>
                        (component.Value.Name == VaultComponentName &&
                         component.Value.Category == VaultComponentCategory))
                    .Key;
                Console.WriteLine($"Vault Component Id : {vaultComponentId}");

                var vaultAccount = new VaultIdentifier(VaultDefaultAccount);
                var vaultDates = new VaultDateParameters(VaultStartDate, VaultEndDate, VaultFrequency);

                var configurationApi = new ConfigurationsApi(GetEngineApiConfiguration());

                var configurationResponse = configurationApi.GetVaultConfigurationsWithHttpInfo(vaultAccount.Id);
                var vaultConfiguration = configurationResponse.Data.First().Key;

                var vaultCalculation = new VaultCalculationParameters(vaultComponentId, vaultAccount, vaultDates, vaultConfiguration);

                var calculationApi = new VaultCalculationsApi(GetEngineApiConfiguration());

                var runCalculationResponse = calculationApi.RunVaultCalculationWithHttpInfo(vaultCalculation);

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

                    runCalculationResponse = calculationApi.GetVaultCalculationByIdWithHttpInfo(calculationId);
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