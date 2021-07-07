using System;
using System.Collections.Generic;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{    
    public static class CommonParameters
    {
        // Add 'ANALYTICS_API_USERNAME_SERIAL' environment variables with the respective username-serial as value
        public static readonly string Username = "fds_demo_c-454747"; // Environment.GetEnvironmentVariable("ANALYTICS_API_USERNAME_SERIAL");

        // Add ANALYTICS_API_PASSWORD environment variables with the respective api key generated on developer portal
        public static readonly string Password = "cxViAP6wCbbSOSSxiIPT5VsdyoNzCObRPBg1h53w"; // Environment.GetEnvironmentVariable("ANALYTICS_API_PASSWORD");

        // Add 'ANALYTICS_API_URL' environment variable with api url as value
        public static readonly string BaseUrl = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ANALYTICS_API_URL")) ? Environment.GetEnvironmentVariable("ANALYTICS_API_URL") : "https://api.factset.com";

        public const string DefaultPADatesAccount = "CLIENT:/AAPI/STATIC_HOLDINGS_20191205.ACCT";
        public const string DefaultVaultDatesAccount = "CLIENT:/BISAM/REPOSITORY/QA/GLOBAL.ACCT";
        public const string DefaultLookupDirectory = "client:";
        public const string PADefaultDocument = "client:/aapi/base_doc";
        public const string PABenchmarkSP50PF = "BENCH:SP50_PF";
        public const string PABenchmarkSP50 = "BENCH:SP50";
        public const string SPARBenchmarkR1000 = "R.1000";
        public const string SPARBenchmarkRussellReturnTypeP = "P";
        public const string SPARBenchmarkRussellPrefix = "RUSSELL";
        public const string SPARBenchmarkRussellReturnType = "GTR";
        public const string SPARDefaultDocument = "Client:/aapi/SPAR3_QA_TEST_DOCUMENT";
        public const string VaultDefaultAccount = "CLIENT:/BISAM/REPOSITORY/QA/SMALL_PORT.ACCT";
        public const string VaultDefaultDocument = "Client:/aapi/VAULT_QA_PI_DEFAULT_LOCKED";
        public const string VaultEndDate = "LAST_REPOSITORY";
        public const string VaultFrequency = "Monthly";
        public const string VaultStartDate = "FIRST_REPOSITORY";
        public const string VaultMultiCalcAccount = "CLIENT:/BISAM/REPOSITORY/QA/GLOBAL.ACCT";
        public const string PubDocumentName = "Client:/AAPI/Puma Test Doc.Pub_bridge_pdf";
        public const string PubAccountName = "BENCH:SP50";
        public const string PubStartDate = "-1M";
        public const string PubEndDate = "0M";
    }
}