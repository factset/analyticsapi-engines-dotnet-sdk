using System;
using System.Net;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;

namespace FactSet.AnalyticsAPI.Engines.Test.Api
{
    public class CommonFunctions
    {
        public static Configuration BuildConfiguration(Enum engine)
        {
            Configuration configuration = null;
            if (CommonParameters.Credentials.ContainsKey(engine))
            {
                configuration = new Configuration
                {
                    BasePath = CommonParameters.BaseUrl,
                    Username = CommonParameters.Credentials[engine].Item1,
                    Password = CommonParameters.Credentials[engine].Item2
                };
            }
            else
            {
                throw new NullReferenceException("Please set the required username and password environment variables.");
            }

            return configuration;
        }

        public static string GetRandomColumnId()
        {
            var columnsApi = new ColumnsApi(BuildConfiguration(Engine.PA));

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