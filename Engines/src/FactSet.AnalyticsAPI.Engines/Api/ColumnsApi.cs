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
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace FactSet.AnalyticsAPI.Engines.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IColumnsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get PA column settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns the default settings of a PA column.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>Column</returns>
        Column GetPAColumnById (string id);

        /// <summary>
        /// Get PA column settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns the default settings of a PA column.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>ApiResponse of Column</returns>
        ApiResponse<Column> GetPAColumnByIdWithHttpInfo (string id);
        /// <summary>
        /// Get PA columns
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA columns that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>Dictionary&lt;string, ColumnSummary&gt;</returns>
        Dictionary<string, ColumnSummary> GetPAColumns (string name = default(string), string category = default(string), string directory = default(string));

        /// <summary>
        /// Get PA columns
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA columns that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, ColumnSummary&gt;</returns>
        ApiResponse<Dictionary<string, ColumnSummary>> GetPAColumnsWithHttpInfo (string name = default(string), string category = default(string), string directory = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IColumnsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get PA column settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns the default settings of a PA column.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>Task of Column</returns>
        System.Threading.Tasks.Task<Column> GetPAColumnByIdAsync (string id);

        /// <summary>
        /// Get PA column settings
        /// </summary>
        /// <remarks>
        /// This endpoint returns the default settings of a PA column.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>Task of ApiResponse (Column)</returns>
        System.Threading.Tasks.Task<ApiResponse<Column>> GetPAColumnByIdAsyncWithHttpInfo (string id);
        /// <summary>
        /// Get PA columns
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA columns that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>Task of Dictionary&lt;string, ColumnSummary&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, ColumnSummary>> GetPAColumnsAsync (string name = default(string), string category = default(string), string directory = default(string));

        /// <summary>
        /// Get PA columns
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the PA columns that can be applied to a calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, ColumnSummary&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, ColumnSummary>>> GetPAColumnsAsyncWithHttpInfo (string name = default(string), string category = default(string), string directory = default(string));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IColumnsApi : IColumnsApiSync, IColumnsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ColumnsApi : IColumnsApi
    {
        private FactSet.AnalyticsAPI.Engines.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ColumnsApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ColumnsApi(String basePath)
        {
            this.Configuration = FactSet.AnalyticsAPI.Engines.Client.Configuration.MergeConfigurations(
                FactSet.AnalyticsAPI.Engines.Client.GlobalConfiguration.Instance,
                new FactSet.AnalyticsAPI.Engines.Client.Configuration { BasePath = basePath }
            );
            this.Client = new FactSet.AnalyticsAPI.Engines.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new FactSet.AnalyticsAPI.Engines.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = FactSet.AnalyticsAPI.Engines.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ColumnsApi(FactSet.AnalyticsAPI.Engines.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = FactSet.AnalyticsAPI.Engines.Client.Configuration.MergeConfigurations(
                FactSet.AnalyticsAPI.Engines.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new FactSet.AnalyticsAPI.Engines.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new FactSet.AnalyticsAPI.Engines.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = FactSet.AnalyticsAPI.Engines.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ColumnsApi(FactSet.AnalyticsAPI.Engines.Client.ISynchronousClient client,FactSet.AnalyticsAPI.Engines.Client.IAsynchronousClient asyncClient, FactSet.AnalyticsAPI.Engines.Client.IReadableConfiguration configuration)
        {
            if(client == null) throw new ArgumentNullException("client");
            if(asyncClient == null) throw new ArgumentNullException("asyncClient");
            if(configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = FactSet.AnalyticsAPI.Engines.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public FactSet.AnalyticsAPI.Engines.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public FactSet.AnalyticsAPI.Engines.Client.ISynchronousClient Client { get; set; }

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
        public FactSet.AnalyticsAPI.Engines.Client.IReadableConfiguration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public FactSet.AnalyticsAPI.Engines.Client.ExceptionFactory ExceptionFactory
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
        /// Get PA column settings This endpoint returns the default settings of a PA column.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>Column</returns>
        public Column GetPAColumnById (string id)
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Column> localVarResponse = GetPAColumnByIdWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get PA column settings This endpoint returns the default settings of a PA column.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>ApiResponse of Column</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Column > GetPAColumnByIdWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'id' when calling ColumnsApi->GetPAColumnById");

            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = FactSet.AnalyticsAPI.Engines.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = FactSet.AnalyticsAPI.Engines.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("id", FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToString(id)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< Column >("/analytics/lookups/v2/engines/pa/columns/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPAColumnById", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get PA column settings This endpoint returns the default settings of a PA column.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>Task of Column</returns>
        public async System.Threading.Tasks.Task<Column> GetPAColumnByIdAsync (string id)
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Column> localVarResponse = await GetPAColumnByIdAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get PA column settings This endpoint returns the default settings of a PA column.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Unique identifier for a column</param>
        /// <returns>Task of ApiResponse (Column)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Column>> GetPAColumnByIdAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'id' when calling ColumnsApi->GetPAColumnById");


            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.PathParameters.Add("id", FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToString(id)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Column>("/analytics/lookups/v2/engines/pa/columns/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPAColumnById", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get PA columns This endpoint lists all the PA columns that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>Dictionary&lt;string, ColumnSummary&gt;</returns>
        public Dictionary<string, ColumnSummary> GetPAColumns (string name = default(string), string category = default(string), string directory = default(string))
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, ColumnSummary>> localVarResponse = GetPAColumnsWithHttpInfo(name, category, directory);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get PA columns This endpoint lists all the PA columns that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>ApiResponse of Dictionary&lt;string, ColumnSummary&gt;</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Dictionary<string, ColumnSummary> > GetPAColumnsWithHttpInfo (string name = default(string), string category = default(string), string directory = default(string))
        {
            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = FactSet.AnalyticsAPI.Engines.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = FactSet.AnalyticsAPI.Engines.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "name", name));
            }
            if (category != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "category", category));
            }
            if (directory != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "directory", directory));
            }

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< Dictionary<string, ColumnSummary> >("/analytics/lookups/v2/engines/pa/columns", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPAColumns", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get PA columns This endpoint lists all the PA columns that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>Task of Dictionary&lt;string, ColumnSummary&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, ColumnSummary>> GetPAColumnsAsync (string name = default(string), string category = default(string), string directory = default(string))
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, ColumnSummary>> localVarResponse = await GetPAColumnsAsyncWithHttpInfo(name, category, directory);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get PA columns This endpoint lists all the PA columns that can be applied to a calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"> (optional)</param>
        /// <param name="category"> (optional)</param>
        /// <param name="directory"> (optional)</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, ColumnSummary&gt;)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, ColumnSummary>>> GetPAColumnsAsyncWithHttpInfo (string name = default(string), string category = default(string), string directory = default(string))
        {

            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "name", name));
            }
            if (category != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "category", category));
            }
            if (directory != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "directory", directory));
            }

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Dictionary<string, ColumnSummary>>("/analytics/lookups/v2/engines/pa/columns", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPAColumns", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
