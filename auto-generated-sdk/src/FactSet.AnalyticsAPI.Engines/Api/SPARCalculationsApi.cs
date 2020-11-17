/* 
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
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
    public interface ISPARCalculationsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Cancel SPAR calculation
        /// </summary>
        /// <remarks>
        /// This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns></returns>
        void CancelSPARCalculationById (string id);

        /// <summary>
        /// Cancel SPAR calculation
        /// </summary>
        /// <remarks>
        /// This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CancelSPARCalculationByIdWithHttpInfo (string id);
        /// <summary>
        /// Get SPAR calculation by id
        /// </summary>
        /// <remarks>
        /// This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Object</returns>
        Object GetSPARCalculationById (string id);

        /// <summary>
        /// Get SPAR calculation by id
        /// </summary>
        /// <remarks>
        /// This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> GetSPARCalculationByIdWithHttpInfo (string id);
        /// <summary>
        /// Run SPAR Calculation
        /// </summary>
        /// <remarks>
        /// This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>Object</returns>
        Object RunSPARCalculation (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters));

        /// <summary>
        /// Run SPAR Calculation
        /// </summary>
        /// <remarks>
        /// This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> RunSPARCalculationWithHttpInfo (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISPARCalculationsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Cancel SPAR calculation
        /// </summary>
        /// <remarks>
        /// This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CancelSPARCalculationByIdAsync (string id);

        /// <summary>
        /// Cancel SPAR calculation
        /// </summary>
        /// <remarks>
        /// This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CancelSPARCalculationByIdAsyncWithHttpInfo (string id);
        /// <summary>
        /// Get SPAR calculation by id
        /// </summary>
        /// <remarks>
        /// This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> GetSPARCalculationByIdAsync (string id);

        /// <summary>
        /// Get SPAR calculation by id
        /// </summary>
        /// <remarks>
        /// This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetSPARCalculationByIdAsyncWithHttpInfo (string id);
        /// <summary>
        /// Run SPAR Calculation
        /// </summary>
        /// <remarks>
        /// This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> RunSPARCalculationAsync (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters));

        /// <summary>
        /// Run SPAR Calculation
        /// </summary>
        /// <remarks>
        /// This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RunSPARCalculationAsyncWithHttpInfo (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISPARCalculationsApi : ISPARCalculationsApiSync, ISPARCalculationsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SPARCalculationsApi : ISPARCalculationsApi
    {
        private FactSet.AnalyticsAPI.Engines.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SPARCalculationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SPARCalculationsApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SPARCalculationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SPARCalculationsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="SPARCalculationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SPARCalculationsApi(FactSet.AnalyticsAPI.Engines.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="SPARCalculationsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SPARCalculationsApi(FactSet.AnalyticsAPI.Engines.Client.ISynchronousClient client,FactSet.AnalyticsAPI.Engines.Client.IAsynchronousClient asyncClient, FactSet.AnalyticsAPI.Engines.Client.IReadableConfiguration configuration)
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
        /// Cancel SPAR calculation This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns></returns>
        public void CancelSPARCalculationById (string id)
        {
             CancelSPARCalculationByIdWithHttpInfo(id);
        }

        /// <summary>
        /// Cancel SPAR calculation This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object> CancelSPARCalculationByIdWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'id' when calling SPARCalculationsApi->CancelSPARCalculationById");

            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
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
            var localVarResponse = this.Client.Delete<Object>("/analytics/engines/spar/v2/calculations/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CancelSPARCalculationById", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel SPAR calculation This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CancelSPARCalculationByIdAsync (string id)
        {
             await CancelSPARCalculationByIdAsyncWithHttpInfo(id);

        }

        /// <summary>
        /// Cancel SPAR calculation This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object>> CancelSPARCalculationByIdAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'id' when calling SPARCalculationsApi->CancelSPARCalculationById");


            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
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

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/analytics/engines/spar/v2/calculations/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CancelSPARCalculationById", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get SPAR calculation by id This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Object</returns>
        public Object GetSPARCalculationById (string id)
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object> localVarResponse = GetSPARCalculationByIdWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get SPAR calculation by id This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>ApiResponse of Object</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Object > GetSPARCalculationByIdWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'id' when calling SPARCalculationsApi->GetSPARCalculationById");

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
            var localVarResponse = this.Client.Get< Object >("/analytics/engines/spar/v2/calculations/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSPARCalculationById", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get SPAR calculation by id This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of Object</returns>
        public async System.Threading.Tasks.Task<Object> GetSPARCalculationByIdAsync (string id)
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object> localVarResponse = await GetSPARCalculationByIdAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get SPAR calculation by id This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">from url, provided from the location header in the Run Calculation endpoint</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object>> GetSPARCalculationByIdAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'id' when calling SPARCalculationsApi->GetSPARCalculationById");


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

            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/analytics/engines/spar/v2/calculations/{id}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSPARCalculationById", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Run SPAR Calculation This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>Object</returns>
        public Object RunSPARCalculation (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters))
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object> localVarResponse = RunSPARCalculationWithHttpInfo(sPARCalculationParameters);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Run SPAR Calculation This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>ApiResponse of Object</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Object > RunSPARCalculationWithHttpInfo (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters))
        {
            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = FactSet.AnalyticsAPI.Engines.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = FactSet.AnalyticsAPI.Engines.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = sPARCalculationParameters;

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post< Object >("/analytics/engines/spar/v2/calculations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunSPARCalculation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Run SPAR Calculation This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>Task of Object</returns>
        public async System.Threading.Tasks.Task<Object> RunSPARCalculationAsync (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters))
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object> localVarResponse = await RunSPARCalculationAsyncWithHttpInfo(sPARCalculationParameters);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Run SPAR Calculation This endpoint runs the SPAR calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.   A successful response will contain the URL to poll for the result of the calculation.    Remarks:    * Any settings in POST body will act as a one-time override over the settings saved in the SPAR template.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sPARCalculationParameters"> (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Object>> RunSPARCalculationAsyncWithHttpInfo (SPARCalculationParameters sPARCalculationParameters = default(SPARCalculationParameters))
        {

            FactSet.AnalyticsAPI.Engines.Client.RequestOptions localVarRequestOptions = new FactSet.AnalyticsAPI.Engines.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            localVarRequestOptions.Data = sPARCalculationParameters;

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/analytics/engines/spar/v2/calculations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunSPARCalculation", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}