using System;
using System.Collections.Generic;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{    
    public static class CommonParameters
    {
        // Add 'ANALYTICS_API_QAR_USERNAME_SERIAL' environment variables with the respective username-serial as value
        public static readonly string Username = Environment.GetEnvironmentVariable("ANALYTICS_API_QAR_USERNAME_SERIAL");

        // Add ANALYTICS_API_QAR_PASSWORD environment variables with the respective api key generated on developer portal
        public static readonly string Password = Environment.GetEnvironmentVariable("ANALYTICS_API_QAR_PASSWORD");

        // Add 'ANALYTICS_API_URL' environment variable with api url as value
        public static readonly string BaseUrl = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ANALYTICS_API_URL")) ? Environment.GetEnvironmentVariable("ANALYTICS_API_URL") : "https://api.factset.com";

        public const string PADefaultDocument = "PA3_DOCUMENTS:PA_API_DEFAULT_DOCUMENT-RBICS";
        public const string PADefaultComponentName = "Weights";
        public const string PADefaultComponentCategory = "Weights / Exposures";
        public const string PABenchmarkSP50  = "BENCH:SP50";
        public const string PABenchmarkR1000 = "BENCH:R.1000";
        public const string SPARDefaultDocument = "pmw_root:/spar_documents/Factset Default Document";
        public const string SPARBenchmarkR1000 = "R.1000";
        public const string SPARBenchmarkR2000 = "R.2000";
        public const string SPARBenchmarkRussellPR1000 = "RUSSELL_P:R.2000";
        public const string SPARBenchmarkRussellPrefix = "RUSSELL";
        public const string SPARBenchmarkRussellReturnType = "GTR";
        public const string VaultDefaultDocument = "CLIENT:/YETI/YETI-API-TEST";
        public const string VaultDefaultAccount = "CLIENT:/YETI/YETI-API-TEST.ACCT";
        public const string VaultStartDate = "20211231";
        public const string VaultEndDate = "20220131";
        public const string PubDocumentName = "Client:/AAPI/Puma Narrative Test.PUB_BRIDGE_PDF";
        public const string PubAccountName = "BENCH:SP50";
        public const string PubStartDate = "-1M";
        public const string PubEndDate = "0M";
        public const string DefaultStartDate = "20180101";
        public const string DefaultEndDate = "20181231";
        public const string DefaultDatesDrequency = "Monthly";
        public const string DefaultDatesAccount = "CLIENT:/BISAM/REPOSITORY/QA/SMALL_PORT.ACCT";
        public const string DefaultLookupDirectory = "client:";
        public static readonly string Quant_Custom_Max_Age = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("QUANT_CUSTOM_MAX_AGE")) 
            ? Environment.GetEnvironmentVariable("QUANT_CUSTOM_MAX_AGE") : "5";
        public const string SPARAccount = "client:/aapi/spar3_qa_test_document";
    }
}