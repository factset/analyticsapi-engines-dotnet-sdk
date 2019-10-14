/* 
 * Engines API
 *
 * Allow clients to fetch Engines Analytics through APIs.
 *
 * The version of the OpenAPI document: 2
 * Contact: analytics.api.support@factset.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using FactSet.AnalyticsAPI.Engines.v2.Client;
using FactSet.AnalyticsAPI.Engines.v2.Model;

namespace FactSet.AnalyticsAPI.Engines.v2.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICurrenciesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get PA currencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Currency&gt;</returns>
        Dictionary<string, Currency> GetPACurrencies ();

        /// <summary>
        /// Get PA currencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Currency&gt;</returns>
        ApiResponse<Dictionary<string, Currency>> GetPACurrenciesWithHttpInfo ();
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICurrenciesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get PA currencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Currency&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, Currency>> GetPACurrenciesAsync ();

        /// <summary>
        /// Get PA currencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Currency&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Currency>>> GetPACurrenciesAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICurrenciesApi : ICurrenciesApiSync, ICurrenciesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CurrenciesApi : ICurrenciesApi
    {
        private FactSet.AnalyticsAPI.Engines.v2.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CurrenciesApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CurrenciesApi(String basePath)
        {
            this.Configuration = FactSet.AnalyticsAPI.Engines.v2.Client.Configuration.MergeConfigurations(
                FactSet.AnalyticsAPI.Engines.v2.Client.GlobalConfiguration.Instance,
                new FactSet.AnalyticsAPI.Engines.v2.Client.Configuration { BasePath = basePath }
            );
            this.Client = new FactSet.AnalyticsAPI.Engines.v2.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new FactSet.AnalyticsAPI.Engines.v2.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = FactSet.AnalyticsAPI.Engines.v2.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CurrenciesApi(FactSet.AnalyticsAPI.Engines.v2.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = FactSet.AnalyticsAPI.Engines.v2.Client.Configuration.MergeConfigurations(
                FactSet.AnalyticsAPI.Engines.v2.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new FactSet.AnalyticsAPI.Engines.v2.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new FactSet.AnalyticsAPI.Engines.v2.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = FactSet.AnalyticsAPI.Engines.v2.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public CurrenciesApi(FactSet.AnalyticsAPI.Engines.v2.Client.ISynchronousClient client,FactSet.AnalyticsAPI.Engines.v2.Client.IAsynchronousClient asyncClient, FactSet.AnalyticsAPI.Engines.v2.Client.IReadableConfiguration configuration)
        {
            if(client == null) throw new ArgumentNullException("client");
            if(asyncClient == null) throw new ArgumentNullException("asyncClient");
            if(configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = FactSet.AnalyticsAPI.Engines.v2.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public FactSet.AnalyticsAPI.Engines.v2.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public FactSet.AnalyticsAPI.Engines.v2.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public FactSet.AnalyticsAPI.Engines.v2.Client.IReadableConfiguration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public FactSet.AnalyticsAPI.Engines.v2.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get PA currencies This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Currency&gt;</returns>
        public Dictionary<string, Currency> GetPACurrencies ()
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<Dictionary<string, Currency>> localVarResponse = GetPACurrenciesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get PA currencies This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Currency&gt;</returns>
        public FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse< Dictionary<string, Currency> > GetPACurrenciesWithHttpInfo ()
        {
            FactSet.AnalyticsAPI.Engines.v2.Client.RequestOptions requestOptions = new FactSet.AnalyticsAPI.Engines.v2.Client.RequestOptions();

            String[] @contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] @accepts = new String[] {
                "application/json"
            };

            var localVarContentType = FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.SelectHeaderContentType(@contentTypes);
            if (localVarContentType != null) requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.SelectHeaderAccept(@accepts);
            if (localVarAccept != null) requestOptions.HeaderParameters.Add("Accept", localVarAccept);


            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = this.Client.Get< Dictionary<string, Currency> >("/analytics/lookups/v2/engines/pa/currencies", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetPACurrencies", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        /// Get PA currencies This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Currency&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, Currency>> GetPACurrenciesAsync ()
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<Dictionary<string, Currency>> localVarResponse = await GetPACurrenciesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get PA currencies This endpoint lists all the PA currencies that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Currency&gt;)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<Dictionary<string, Currency>>> GetPACurrenciesAsyncWithHttpInfo ()
        {

            FactSet.AnalyticsAPI.Engines.v2.Client.RequestOptions requestOptions = new FactSet.AnalyticsAPI.Engines.v2.Client.RequestOptions();

            String[] @contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] @accepts = new String[] {
                "application/json"
            };
            
            foreach (var contentType in @contentTypes)
                requestOptions.HeaderParameters.Add("Content-Type", contentType);
            
            foreach (var accept in @accepts)
                requestOptions.HeaderParameters.Add("Accept", accept);
            

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = await this.AsynchronousClient.GetAsync<Dictionary<string, Currency>>("/analytics/lookups/v2/engines/pa/currencies", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetPACurrencies", response);
                if (exception != null) throw exception;
            }

            return response;
        }

    }
}
