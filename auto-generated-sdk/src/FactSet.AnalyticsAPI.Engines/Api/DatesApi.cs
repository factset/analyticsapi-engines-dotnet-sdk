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
    public interface IDatesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Convert PA dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>DateParametersSummary</returns>
        DateParametersSummary ConvertPADatesToAbsoluteFormat(string enddate, string componentid, string account, string startdate = default(string));

        /// <summary>
        /// Convert PA dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>ApiResponse of DateParametersSummary</returns>
        ApiResponse<DateParametersSummary> ConvertPADatesToAbsoluteFormatWithHttpInfo(string enddate, string componentid, string account, string startdate = default(string));
        /// <summary>
        /// Convert Vault dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>DateParametersSummary</returns>
        DateParametersSummary ConvertVaultDatesToAbsoluteFormat(string enddate, string componentid, string account, string startdate = default(string));

        /// <summary>
        /// Convert Vault dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>ApiResponse of DateParametersSummary</returns>
        ApiResponse<DateParametersSummary> ConvertVaultDatesToAbsoluteFormatWithHttpInfo(string enddate, string componentid, string account, string startdate = default(string));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDatesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Convert PA dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DateParametersSummary</returns>
        System.Threading.Tasks.Task<DateParametersSummary> ConvertPADatesToAbsoluteFormatAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Convert PA dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DateParametersSummary)</returns>
        System.Threading.Tasks.Task<ApiResponse<DateParametersSummary>> ConvertPADatesToAbsoluteFormatWithHttpInfoAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Convert Vault dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DateParametersSummary</returns>
        System.Threading.Tasks.Task<DateParametersSummary> ConvertVaultDatesToAbsoluteFormatAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Convert Vault dates to absolute format
        /// </summary>
        /// <remarks>
        /// This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DateParametersSummary)</returns>
        System.Threading.Tasks.Task<ApiResponse<DateParametersSummary>> ConvertVaultDatesToAbsoluteFormatWithHttpInfoAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDatesApi : IDatesApiSync, IDatesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DatesApi : IDatesApi
    {
        private FactSet.AnalyticsAPI.Engines.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DatesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DatesApi(String basePath)
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
        /// Initializes a new instance of the <see cref="DatesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DatesApi(FactSet.AnalyticsAPI.Engines.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="DatesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public DatesApi(FactSet.AnalyticsAPI.Engines.Client.ISynchronousClient client, FactSet.AnalyticsAPI.Engines.Client.IAsynchronousClient asyncClient, FactSet.AnalyticsAPI.Engines.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

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
        public FactSet.AnalyticsAPI.Engines.Client.IReadableConfiguration Configuration { get; set; }

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
        /// Convert PA dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>DateParametersSummary</returns>
        public DateParametersSummary ConvertPADatesToAbsoluteFormat(string enddate, string componentid, string account, string startdate = default(string))
        {
            FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary> localVarResponse = ConvertPADatesToAbsoluteFormatWithHttpInfo(enddate, componentid, account, startdate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Convert PA dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>ApiResponse of DateParametersSummary</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary> ConvertPADatesToAbsoluteFormatWithHttpInfo(string enddate, string componentid, string account, string startdate = default(string))
        {
            // verify the required parameter 'enddate' is set
            if (enddate == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'enddate' when calling DatesApi->ConvertPADatesToAbsoluteFormat");

            // verify the required parameter 'componentid' is set
            if (componentid == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'componentid' when calling DatesApi->ConvertPADatesToAbsoluteFormat");

            // verify the required parameter 'account' is set
            if (account == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'account' when calling DatesApi->ConvertPADatesToAbsoluteFormat");

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

            if (startdate != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "startdate", startdate));
            }
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "enddate", enddate));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "componentid", componentid));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "account", account));

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DateParametersSummary>("/analytics/lookups/v2/engines/pa/dates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConvertPADatesToAbsoluteFormat", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Convert PA dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DateParametersSummary</returns>
        public async System.Threading.Tasks.Task<DateParametersSummary> ConvertPADatesToAbsoluteFormatAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary> localVarResponse = await ConvertPADatesToAbsoluteFormatWithHttpInfoAsync(enddate, componentid, account, startdate, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Convert PA dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a PA calculation. For more information on FactSet date format, please refer to the PA Engine API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DateParametersSummary)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary>> ConvertPADatesToAbsoluteFormatWithHttpInfoAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'enddate' is set
            if (enddate == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'enddate' when calling DatesApi->ConvertPADatesToAbsoluteFormat");

            // verify the required parameter 'componentid' is set
            if (componentid == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'componentid' when calling DatesApi->ConvertPADatesToAbsoluteFormat");

            // verify the required parameter 'account' is set
            if (account == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'account' when calling DatesApi->ConvertPADatesToAbsoluteFormat");


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

            if (startdate != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "startdate", startdate));
            }
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "enddate", enddate));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "componentid", componentid));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "account", account));

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DateParametersSummary>("/analytics/lookups/v2/engines/pa/dates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConvertPADatesToAbsoluteFormat", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Convert Vault dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>DateParametersSummary</returns>
        public DateParametersSummary ConvertVaultDatesToAbsoluteFormat(string enddate, string componentid, string account, string startdate = default(string))
        {
            FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary> localVarResponse = ConvertVaultDatesToAbsoluteFormatWithHttpInfo(enddate, componentid, account, startdate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Convert Vault dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <returns>ApiResponse of DateParametersSummary</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary> ConvertVaultDatesToAbsoluteFormatWithHttpInfo(string enddate, string componentid, string account, string startdate = default(string))
        {
            // verify the required parameter 'enddate' is set
            if (enddate == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'enddate' when calling DatesApi->ConvertVaultDatesToAbsoluteFormat");

            // verify the required parameter 'componentid' is set
            if (componentid == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'componentid' when calling DatesApi->ConvertVaultDatesToAbsoluteFormat");

            // verify the required parameter 'account' is set
            if (account == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'account' when calling DatesApi->ConvertVaultDatesToAbsoluteFormat");

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

            if (startdate != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "startdate", startdate));
            }
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "enddate", enddate));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "componentid", componentid));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "account", account));

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DateParametersSummary>("/analytics/lookups/v2/engines/vault/dates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConvertVaultDatesToAbsoluteFormat", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Convert Vault dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DateParametersSummary</returns>
        public async System.Threading.Tasks.Task<DateParametersSummary> ConvertVaultDatesToAbsoluteFormatAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary> localVarResponse = await ConvertVaultDatesToAbsoluteFormatWithHttpInfoAsync(enddate, componentid, account, startdate, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Convert Vault dates to absolute format This endpoint converts the given start and end dates in FactSet date format to yyyymmdd format for a Vault calculation. For more information on FactSet date format, please refer to the Vault API documentation under the &#39;API Documentation&#39; section in the developer portal.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enddate">End Date</param>
        /// <param name="componentid">Vault Component Id</param>
        /// <param name="account">Account</param>
        /// <param name="startdate">Start Date (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DateParametersSummary)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<DateParametersSummary>> ConvertVaultDatesToAbsoluteFormatWithHttpInfoAsync(string enddate, string componentid, string account, string startdate = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'enddate' is set
            if (enddate == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'enddate' when calling DatesApi->ConvertVaultDatesToAbsoluteFormat");

            // verify the required parameter 'componentid' is set
            if (componentid == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'componentid' when calling DatesApi->ConvertVaultDatesToAbsoluteFormat");

            // verify the required parameter 'account' is set
            if (account == null)
                throw new FactSet.AnalyticsAPI.Engines.Client.ApiException(400, "Missing required parameter 'account' when calling DatesApi->ConvertVaultDatesToAbsoluteFormat");


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

            if (startdate != null)
            {
                localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "startdate", startdate));
            }
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "enddate", enddate));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "componentid", componentid));
            localVarRequestOptions.QueryParameters.Add(FactSet.AnalyticsAPI.Engines.Client.ClientUtils.ParameterToMultiMap("", "account", account));

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DateParametersSummary>("/analytics/lookups/v2/engines/vault/dates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ConvertVaultDatesToAbsoluteFormat", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
