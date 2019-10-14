using System;
using System.Net;

using FactSet.AnalyticsAPI.Engines.v2.Api;
using FactSet.AnalyticsAPI.Engines.v2.Client;

namespace FactSet.AnalyticsAPI.Engines.v2.Test.Api
{
    public class CommonFunctions
    {
        public static Configuration BuildConfiguration()
        {
            Configuration configuration = null;
            if (!string.IsNullOrEmpty(CommonParameters.UserName) && !string.IsNullOrEmpty(CommonParameters.Password))
            {
                configuration = new Configuration
                {
                    BasePath = CommonParameters.BaseUrl,
                    Username = CommonParameters.UserName,
                    Password = CommonParameters.Password
                };
            }
            else
            {
                throw new NullReferenceException("Please set ANALYTICS_API_USERNAME_SERIAL and ANALYTICS_API_PASSWORD environment variables.");
            }

            return configuration;
        }

        public static string GetRandomColumnId()
        {
            var columnsApi = new ColumnsApi(BuildConfiguration());

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var columnsGetAllResponse = columnsApi.GetPAColumnsWithHttpInfo();

            var r = new Random();
            var randomIndex = r.Next(columnsGetAllResponse.Data.Count);

            var currentIndex = 0;
            foreach (var pair in columnsGetAllResponse.Data)
            {
                if (currentIndex == randomIndex)
                {
                    return pair.Key;
                }

                currentIndex++;
            }

            return null;
        }
    }
}