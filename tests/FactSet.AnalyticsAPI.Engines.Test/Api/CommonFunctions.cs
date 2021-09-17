using System;
using System.Collections.Generic;
using System.Net;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    public class CommonFunctions
    {
        public static Configuration BuildConfiguration()
        {
            return new Configuration(new Dictionary<string, string>(), new Dictionary<string, string>(),
                new Dictionary<string, string>(), CommonParameters.BaseUrl)
            {
                BasePath = CommonParameters.BaseUrl,
                Username = CommonParameters.Username,
                Password = CommonParameters.Password
            };
        }

        public static string GetRandomColumnId()
        {
            var columnsApi = new ColumnsApi(CommonFunctions.BuildConfiguration());

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var columnsGetAllResponse = columnsApi.GetPAColumnsWithHttpInfo();

            var r = new Random();
            var randomIndex = r.Next(columnsGetAllResponse.Data.Data.Count);

            var currentIndex = 0;
            foreach (var pair in columnsGetAllResponse.Data.Data)
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