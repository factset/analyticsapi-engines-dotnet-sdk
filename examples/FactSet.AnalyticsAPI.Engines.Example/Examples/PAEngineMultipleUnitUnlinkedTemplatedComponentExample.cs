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
    public class PAEngineMultipleUnitUnlinkedTemplatedComponentExample
    {
        private static Configuration _engineApiConfiguration;
        private static readonly string BasePath = Environment.GetEnvironmentVariable("FACTSET_HOST");
        private static readonly string UserName = Environment.GetEnvironmentVariable("FACTSET_USERNAME");
        private static readonly string Password = Environment.GetEnvironmentVariable("FACTSET_PASSWORD");
        private static readonly string ProxyUrl = Environment.GetEnvironmentVariable("PROXY_URL");

        private const string Portfolio = "BENCH:SP50";
        private const string Benchmark = "BENCH:R.1000";

        private const string ColumnName = "Port. Average Weight";
        private const string ColumnCategory = "Portfolio/Position Data";
        private const string Directory = "Factset";
        private const string ColumnStatisticName = "Active Weights";

        private const string GroupCategory = "Country & Region/JP Morgan/JP Morgan CEMBI ";
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

                var calculationApi = new PACalculationsApi(configuration: GetApiConfiguration());

                var calculationResponse = calculationApi.PostAndCalculateWithHttpInfo(xFactSetApiLongRunningDeadline: null, cacheControl: null, pACalculationParametersRoot: calculationParameters);
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

                    getStatusResponse = calculationApi.GetCalculationStatusByIdWithHttpInfo(id: calculationId);
                    status = getStatusResponse.Data;
                }
                Console.WriteLine("Calculation Completed");

                
                foreach (var calculation in status.Data.Units)
                {
                    if (calculation.Value.Status == CalculationUnitStatus.StatusEnum.Success)
                    {
                        var resultResponse = calculationApi.GetCalculationUnitResultByIdWithHttpInfo(id: calculationId, unitId: calculation.Key);
                        Console.WriteLine($"Calculation Id: {calculationId} with Unit Id: {calculation.Key} Succeeded!!!");
                        PrintResult(result: resultResponse.Data);
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
            var columnsApi = new ColumnsApi(configuration: GetApiConfiguration());
            var column = columnsApi.GetPAColumns(name: ColumnName, category: ColumnCategory, directory: Directory);
            var columnId = column.Data.Keys.ToList()[0];

            var columnStatisticsApi = new ColumnStatisticsApi(configuration: GetApiConfiguration());
            var getAllColumnStatistics = columnStatisticsApi.GetPAColumnStatistics();
            var columnStatisticId = new List<string>()
            {
                getAllColumnStatistics.Data.Keys.FirstOrDefault(id =>
                    (getAllColumnStatistics.Data[id].Name == ColumnStatisticName))
            };

            var columnsIdentifier = new PACalculationColumn(id: columnId, statistics: columnStatisticId);
            var columns = new List<PACalculationColumn> { columnsIdentifier };

            var groupsApi = new GroupsApi(configuration: GetApiConfiguration());
            var getPAGroups = groupsApi.GetPAGroups();
            var groupId = getPAGroups.Data.Keys.FirstOrDefault(id => (getPAGroups.Data[id].Name == GroupName
                                                                      && getPAGroups.Data[id].Directory == Directory
                                                                      && getPAGroups.Data[id].Category == GroupCategory));


            var groupsIdentifier = new PACalculationGroup(id: groupId);
            var groups = new List<PACalculationGroup> { groupsIdentifier };

            var paAccounts = new List<PAIdentifier> { new PAIdentifier(id: Portfolio) };
            var paBenchmarks = new List<PAIdentifier> { new PAIdentifier(id: Benchmark) };
            var paDates = new PADateParameters(startdate: StartDate, enddate: EndDate, frequency: Frequency);


            var unlinkedPATemplateParametersRoot = GetUnlinkedPATemplateParameters(paAccounts: paAccounts, paBenchmarks: paBenchmarks, paDates: paDates, columns: columns, groups: groups);
            var unlinkedPATemplateApi = new UnlinkedPATemplatesApi(configuration: GetApiConfiguration());
            var response = unlinkedPATemplateApi.CreateUnlinkedPATemplates(unlinkedPATemplateParametersRoot: unlinkedPATemplateParametersRoot);

            var parentTemplateId = response.Data.Id;

            var templatedPAComponentParametersRoot =
                GetTemplatedPAComponentParametersRoot(paAccounts: paAccounts, paBenchmarks: paBenchmarks, paDates: paDates, columns: columns, groups: groups, parentTemplateId: parentTemplateId);

            var templatedPAComponentsApi = new TemplatedPAComponentsApi(configuration: GetApiConfiguration());

            var templatedPAComponentsResponse = templatedPAComponentsApi.CreateTemplatedPAComponents(templatedPAComponentParametersRoot: templatedPAComponentParametersRoot);

            var paComponentId = templatedPAComponentsResponse.Data.Id;

            Console.WriteLine($"PA Component Id : {paComponentId}");
            
            var paCalculation = new PACalculationParameters(componentid: paComponentId, accounts: paAccounts, benchmarks: paBenchmarks);

            var calculationParameters = new PACalculationParametersRoot
            {
                Data = new Dictionary<string, PACalculationParameters> {
                    { "1", paCalculation },
                    { "2", paCalculation }
                }
            };

            return calculationParameters;
        }

        private static void PrintResult(ObjectRoot result)
        {
            Console.WriteLine("Calculation Result");

            // converting the data to Package object
            var stachBuilder = StachExtensionFactory.GetRowOrganizedBuilder();
            var stachExtension = stachBuilder.SetPackage(package: result.Data).Build();
            // To convert package to 2D tables.
            var tables = stachExtension.ConvertToTable();

            Console.WriteLine(tables[0]);
        }

        private static UnlinkedPATemplateParametersRoot GetUnlinkedPATemplateParameters(List<PAIdentifier> paAccounts, List<PAIdentifier> paBenchmarks, 
            PADateParameters paDates, List<PACalculationColumn> columns, List<PACalculationGroup> groups)
        {
            var mandatory = new List<string>() { "accounts", "benchmarks" };
            var optional = new List<string>() { "groups", "columns", "currencyisocode", "componentdetail", "dates" };
            var unlinkedPATemplateContent = new TemplateContentTypes(mandatory: mandatory, optional: optional);
            var unlinkedPATemplateParameters = new UnlinkedPATemplateParameters(
                directory: UnlinkedPATemplateDirectory,
                templateTypeId: UnlinkedPATemplateTypeId,
                description: UnlinkedPATemplateDescription,
                accounts: paAccounts,
                benchmarks: paBenchmarks,
                columns: columns,
                dates: paDates, 
                groups: groups,
                currencyisocode: CurrencyISOCode,
                componentdetail: ComponentDetail,
                content: unlinkedPATemplateContent
            );

            var unlinkedPATemplateParametersRoot = new UnlinkedPATemplateParametersRoot(data: unlinkedPATemplateParameters);
            return unlinkedPATemplateParametersRoot;
        }

        private static TemplatedPAComponentParametersRoot GetTemplatedPAComponentParametersRoot(
            List<PAIdentifier> paAccounts, List<PAIdentifier> paBenchmarks,
            PADateParameters paDates, List<PACalculationColumn> columns, List<PACalculationGroup> groups, string parentTemplateId)
        {
            var templatedPAComponentData = new PAComponentData(
                accounts: paAccounts,
                benchmarks: paBenchmarks,
                groups: groups,
                columns: columns,
                dates: paDates,
                currencyisocode: CurrencyISOCode,
                componentdetail: ComponentDetail
            );

            var templatedPAComponentParameters = new TemplatedPAComponentParameters(
                directory: TemplatedPAComponentDirectory,
                parentTemplateId: parentTemplateId,
                description: TemplatedPAComponentDescription,
                componentData: templatedPAComponentData
            );

            var templatedPAComponentParametersRoot =
                new TemplatedPAComponentParametersRoot(data: templatedPAComponentParameters);

            return templatedPAComponentParametersRoot;
        }
    }
}

