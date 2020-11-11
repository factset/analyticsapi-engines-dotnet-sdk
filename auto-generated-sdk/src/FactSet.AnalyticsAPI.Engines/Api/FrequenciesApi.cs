/* 
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v2:[pa,spar,vault,pub],v1:[fiab,fi,axp,afi,npo,bpm,fpo]
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
    public interface IFrequenciesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get PA frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Frequency&gt;</returns>
        Dictionary<string, Frequency> GetPAFrequencies ();

        /// <summary>
        /// Get PA frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Frequency&gt;</returns>
        ApiResponse<Dictionary<string, Frequency>> GetPAFrequenciesWithHttpInfo ();
        /// <summary>
        /// Get SPAR frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Frequency&gt;</returns>
        Dictionary<string, Frequency> GetSPARFrequencies ();

        /// <summary>
        /// Get SPAR frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Frequency&gt;</returns>
        ApiResponse<Dictionary<string, Frequency>> GetSPARFrequenciesWithHttpInfo ();
        /// <summary>
        /// Get Vault frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Frequency&gt;</returns>
        Dictionary<string, Frequency> GetVaultFrequencies ();

        /// <summary>
        /// Get Vault frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Frequency&gt;</returns>
        ApiResponse<Dictionary<string, Frequency>> GetVaultFrequenciesWithHttpInfo ();
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFrequenciesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get PA frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Frequency&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, Frequency>> GetPAFrequenciesAsync ();

        /// <summary>
        /// Get PA frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Frequency&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Frequency>>> GetPAFrequenciesAsyncWithHttpInfo ();
        /// <summary>
        /// Get SPAR frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Frequency&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, Frequency>> GetSPARFrequenciesAsync ();

        /// <summary>
        /// Get SPAR frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Frequency&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Frequency>>> GetSPARFrequenciesAsyncWithHttpInfo ();
        /// <summary>
        /// Get Vault frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Frequency&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, Frequency>> GetVaultFrequenciesAsync ();

        /// <summary>
        /// Get Vault frequencies
        /// </summary>
        /// <remarks>
        /// This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Frequency&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, Frequency>>> GetVaultFrequenciesAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFrequenciesApi : IFrequenciesApiSync, IFrequenciesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class FrequenciesApi : IFrequenciesApi
    {
        private FactSet.AnalyticsAPI.Engines.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrequenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FrequenciesApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrequenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FrequenciesApi(String basePath)
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
        /// Initializes a new instance of the <see cref="FrequenciesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public FrequenciesApi(FactSet.AnalyticsAPI.Engines.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="FrequenciesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public FrequenciesApi(FactSet.AnalyticsAPI.Engines.Client.ISynchronousClient client,FactSet.AnalyticsAPI.Engines.Client.IAsynchronousClient asyncClient, FactSet.AnalyticsAPI.Engines.Client.IReadableConfiguration configuration)
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
        /// Get PA frequencies This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Frequency&gt;</returns>
        public Dictionary<string, Frequency> GetPAFrequencies ()
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>> localVarResponse = GetPAFrequenciesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get PA frequencies This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Frequency&gt;</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Dictionary<string, Frequency> > GetPAFrequenciesWithHttpInfo ()
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


            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< Dictionary<string, Frequency> >("/analytics/lookups/v2/engines/pa/frequencies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPAFrequencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get PA frequencies This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Frequency&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, Frequency>> GetPAFrequenciesAsync ()
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>> localVarResponse = await GetPAFrequenciesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get PA frequencies This endpoint lists all the frequencies that can be applied to a PA calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Frequency&gt;)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>>> GetPAFrequenciesAsyncWithHttpInfo ()
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
            

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Dictionary<string, Frequency>>("/analytics/lookups/v2/engines/pa/frequencies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPAFrequencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get SPAR frequencies This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Frequency&gt;</returns>
        public Dictionary<string, Frequency> GetSPARFrequencies ()
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>> localVarResponse = GetSPARFrequenciesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get SPAR frequencies This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Frequency&gt;</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Dictionary<string, Frequency> > GetSPARFrequenciesWithHttpInfo ()
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


            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< Dictionary<string, Frequency> >("/analytics/lookups/v2/engines/spar/frequencies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSPARFrequencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get SPAR frequencies This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Frequency&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, Frequency>> GetSPARFrequenciesAsync ()
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>> localVarResponse = await GetSPARFrequenciesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get SPAR frequencies This endpoint lists all the frequencies that can be applied to a SPAR calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Frequency&gt;)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>>> GetSPARFrequenciesAsyncWithHttpInfo ()
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
            

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Dictionary<string, Frequency>>("/analytics/lookups/v2/engines/spar/frequencies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSPARFrequencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Vault frequencies This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Dictionary&lt;string, Frequency&gt;</returns>
        public Dictionary<string, Frequency> GetVaultFrequencies ()
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>> localVarResponse = GetVaultFrequenciesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get Vault frequencies This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Dictionary&lt;string, Frequency&gt;</returns>
        public FactSet.AnalyticsAPI.Engines.Client.ApiResponse< Dictionary<string, Frequency> > GetVaultFrequenciesWithHttpInfo ()
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


            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get< Dictionary<string, Frequency> >("/analytics/lookups/v2/engines/vault/frequencies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVaultFrequencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Vault frequencies This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Dictionary&lt;string, Frequency&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, Frequency>> GetVaultFrequenciesAsync ()
        {
             FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>> localVarResponse = await GetVaultFrequenciesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get Vault frequencies This endpoint lists all the frequencies that can be applied to a Vault calculation.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, Frequency&gt;)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.Client.ApiResponse<Dictionary<string, Frequency>>> GetVaultFrequenciesAsyncWithHttpInfo ()
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
            

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Dictionary<string, Frequency>>("/analytics/lookups/v2/engines/vault/frequencies", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVaultFrequencies", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
