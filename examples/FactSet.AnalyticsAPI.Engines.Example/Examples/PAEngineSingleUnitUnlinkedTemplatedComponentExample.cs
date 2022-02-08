using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Diagnostics;

using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

using FactSet.Protobuf.Stach.Extensions;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public class PAEngineSingleUnitUnlinkedTemplatedComponentExample
    {
        private static Configuration _engineApiConfiguration;
        //private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        //private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        //private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");

        private static readonly string BasePath = "https://api.factset.com";
        private static readonly string UserName = "FDSQAR_C-1021374";
        private static readonly string Password = "FIScMWwVbr3WMJ4RIlv3tMsc8T7b0w9S6P72oJX5";

        private const string PADocument = "PA_DOCUMENTS:DEFAULT";
        private const string ComponentName = "Weights";
        private const string ComponentCategory = "Weights / Exposures";
        private const string Portfolio = "BENCH:SP50";
        private const string Benchmark = "BENCH:R.1000";

        private const string ColumnName = "Port. Average Weight";
        private const string ColumnCategory = "Portfolio/Position Data";
        private const string Directory = "Factset";
        private const string ColumnStatisticName = "Active Weights";

        private const string GroupCategory = "JP Morgan CEMBI ";
        private const string GroupName = "Country - JP Morgan CEMBI ";

        private const string UnlinkedPATemplateDirectory = "Personal:UnlinkedPATemplates";
        private const string UnlinkedPATemplateTypeId = "996E90B981AEE83F14029ED3D309FB3F03EC6E2ACC7FD42C22CBD5D279502CFD";
        private const string UnlinkedPATemplateDescription = "This is an unlinked PA template that only returns security level data";
        private const string StartDate = "20180101";
        private const string EndDate = "20181231";
        private const string Frequency = "Monthly";
        private const string CurrencyISOCode = "USD";
        private const string ComponentDetail = "GROUPS";

        private const string TemplatedPAComponentDirectory = "Personal:TemplatedPAComponents/";
        private const string TemplatedPAComponentDescription = "This is a templated PA component";


        public static void Main(string[] args)
        {
            try
            {
                var calculationParameters = GetPaCalculationParameters();

                var calculationApi = new PACalculationsApi(GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, null, calculationParameters);
                // Comment the above line and uncomment the below lines to add cache control configuration. Results are by default cached for 12 hours; Setting max-stale=300 will fetch a cached result which is at max 5 minutes older.
                //var cacheControl = "max-stale=300";
                //var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(null, cacheControl, calculationParameters);

                if (calculationResponse.StatusCode == HttpStatusCode.Created)
                {
                    ObjectRoot result = (ObjectRoot)calculationResponse.Data;
                    PrintResult(result);
                    return;
                }

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
                        PrintResult(resultResponse.Data);
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


        private static PACalculationParametersRoot GetPaCalculationParameters()
        {
            var columnsApi = new ColumnsApi(GetApiConfiguration());
            var column = columnsApi.GetPAColumns(ColumnName, ColumnCategory, Directory);
            var columnId = column.Data.Keys.ToList()[0];

            var columnStatisticsApi = new ColumnStatisticsApi(GetApiConfiguration());
            var getAllColumnStatistics = columnStatisticsApi.GetPAColumnStatistics();
            var desiredColumnStatistic = new ColumnStatistic(ColumnStatisticName);
            var columnStatisticId = new List<string>()
            {
                getAllColumnStatistics.Data.Keys.FirstOrDefault(id =>
                    (getAllColumnStatistics.Data[id].Name == desiredColumnStatistic.Name))
            };

            var columnsIdentifier = new PACalculationColumn(columnId, columnStatisticId);
            var columns = new List<PACalculationColumn> { columnsIdentifier };

            var groupsApi = new GroupsApi(GetApiConfiguration());
            var getPAGroups = groupsApi.GetPAGroups();
            var desiredGroup = new Group(GroupName, Directory, GroupCategory);
            var groupId = getPAGroups.Data.Keys.FirstOrDefault(id => (getPAGroups.Data[id].Name == desiredGroup.Name
                                                                      && getPAGroups.Data[id].Directory == desiredGroup.Directory
                                                                      && getPAGroups.Data[id].Category == desiredGroup.Category));


            var groupsIdentifier = new PACalculationGroup(groupId);
            var groups = new List<PACalculationGroup> { groupsIdentifier };

            var paAccounts = new List<PAIdentifier> { new PAIdentifier(Portfolio) };
            var paBenchmarks = new List<PAIdentifier> { new PAIdentifier(Benchmark) };
            var paDates = new PADateParameters(StartDate, EndDate, Frequency);


            var unlinkedPATemplateParametersRoot = GetUnlinkedPATemplateParameters(paAccounts,paBenchmarks, paDates, columns, groups);
            var unlinkedPATemplateApi = new UnlinkedPATemplatesApi(GetApiConfiguration());
            var response = unlinkedPATemplateApi.CreateUnlinkedPATemplates(unlinkedPATemplateParametersRoot);

            var parentTemplateId = response.Data.Id;

            var templatedPAComponentParametersRoot =
                GetTemplatedPAComponentParametersRoot(paAccounts, paBenchmarks, paDates, columns, groups, parentTemplateId);

            var templatedPAComponentsApi = new TemplatedPAComponentsApi(GetApiConfiguration());
            var templatedPAComponentsResponse = templatedPAComponentsApi.CreateTemplatedPAComponents(templatedPAComponentParametersRoot);

            var paComponentId = templatedPAComponentsResponse.Data.Id;

            var componentsApi = new ComponentsApi(GetApiConfiguration());
            Console.WriteLine($"PA Component Id : {paComponentId}");
            
            var paCalculation = new PACalculationParameters(paComponentId, paAccounts, paBenchmarks);

            var calculationParameters = new PACalculationParametersRoot
            {
                Data = new Dictionary<string, PACalculationParameters> { { "1", paCalculation } }
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

        private static UnlinkedPATemplateParametersRoot GetUnlinkedPATemplateParameters(List<PAIdentifier> paAccounts, List<PAIdentifier> paBenchmarks, 
            PADateParameters paDates, List<PACalculationColumn> columns, List<PACalculationGroup> groups)
        {
            var mandatory = new List<string>() { "accounts", "benchmarks" };
            var optional = new List<string>() { "groups", "columns", "currencyisocode", "componentdetail" };
            var locked = new List<string>() { "dates" };
            var unlinkedPATemplateContent = new TemplateContentTypes(mandatory, optional, locked);
            var unlinkedPATemplateParameters = new UnlinkedPATemplateParameters(UnlinkedPATemplateDirectory,
                UnlinkedPATemplateTypeId, UnlinkedPATemplateDescription,
                paAccounts, paBenchmarks, columns, paDates, groups,
                CurrencyISOCode, ComponentDetail, unlinkedPATemplateContent);

            var unlinkedPATemplateParametersRoot = new UnlinkedPATemplateParametersRoot(unlinkedPATemplateParameters);
            return unlinkedPATemplateParametersRoot;
        }

        private static TemplatedPAComponentParametersRoot GetTemplatedPAComponentParametersRoot(
            List<PAIdentifier> paAccounts, List<PAIdentifier> paBenchmarks,
            PADateParameters paDates, List<PACalculationColumn> columns, List<PACalculationGroup> groups, string parentTemplateId)
        {
            var templatedPAComponentData =
                new PAComponentData(paAccounts, paBenchmarks, groups, columns, paDates, CurrencyISOCode, ComponentDetail);
            var templatedPAComponentParameters = new TemplatedPAComponentParameters(TemplatedPAComponentDirectory,
                parentTemplateId, TemplatedPAComponentDescription, templatedPAComponentData);
            var templatedPAComponentParametersRoot =
                new TemplatedPAComponentParametersRoot(templatedPAComponentParameters);

            return templatedPAComponentParametersRoot;
        }
    }
}

