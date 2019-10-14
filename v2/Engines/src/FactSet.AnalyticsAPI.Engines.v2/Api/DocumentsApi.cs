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
    public interface IDocumentsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get PA3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>DocumentDirectories</returns>
        DocumentDirectories GetPA3Documents (string path);

        /// <summary>
        /// Get PA3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>ApiResponse of DocumentDirectories</returns>
        ApiResponse<DocumentDirectories> GetPA3DocumentsWithHttpInfo (string path);
        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>DocumentDirectories</returns>
        DocumentDirectories GetSPAR3Documents (string path);

        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>ApiResponse of DocumentDirectories</returns>
        ApiResponse<DocumentDirectories> GetSPAR3DocumentsWithHttpInfo (string path);
        /// <summary>
        /// Get Vault documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>DocumentDirectories</returns>
        DocumentDirectories GetVaultDocuments (string path);

        /// <summary>
        /// Get Vault documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>ApiResponse of DocumentDirectories</returns>
        ApiResponse<DocumentDirectories> GetVaultDocumentsWithHttpInfo (string path);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDocumentsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get PA3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>Task of DocumentDirectories</returns>
        System.Threading.Tasks.Task<DocumentDirectories> GetPA3DocumentsAsync (string path);

        /// <summary>
        /// Get PA3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>Task of ApiResponse (DocumentDirectories)</returns>
        System.Threading.Tasks.Task<ApiResponse<DocumentDirectories>> GetPA3DocumentsAsyncWithHttpInfo (string path);
        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of DocumentDirectories</returns>
        System.Threading.Tasks.Task<DocumentDirectories> GetSPAR3DocumentsAsync (string path);

        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of ApiResponse (DocumentDirectories)</returns>
        System.Threading.Tasks.Task<ApiResponse<DocumentDirectories>> GetSPAR3DocumentsAsyncWithHttpInfo (string path);
        /// <summary>
        /// Get Vault documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of DocumentDirectories</returns>
        System.Threading.Tasks.Task<DocumentDirectories> GetVaultDocumentsAsync (string path);

        /// <summary>
        /// Get Vault documents and sub-directories in a directory
        /// </summary>
        /// <remarks>
        /// This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </remarks>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of ApiResponse (DocumentDirectories)</returns>
        System.Threading.Tasks.Task<ApiResponse<DocumentDirectories>> GetVaultDocumentsAsyncWithHttpInfo (string path);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDocumentsApi : IDocumentsApiSync, IDocumentsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DocumentsApi : IDocumentsApi
    {
        private FactSet.AnalyticsAPI.Engines.v2.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DocumentsApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DocumentsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="DocumentsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DocumentsApi(FactSet.AnalyticsAPI.Engines.v2.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="DocumentsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public DocumentsApi(FactSet.AnalyticsAPI.Engines.v2.Client.ISynchronousClient client,FactSet.AnalyticsAPI.Engines.v2.Client.IAsynchronousClient asyncClient, FactSet.AnalyticsAPI.Engines.v2.Client.IReadableConfiguration configuration)
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
        /// Get PA3 documents and sub-directories in a directory This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>DocumentDirectories</returns>
        public DocumentDirectories GetPA3Documents (string path)
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories> localVarResponse = GetPA3DocumentsWithHttpInfo(path);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get PA3 documents and sub-directories in a directory This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>ApiResponse of DocumentDirectories</returns>
        public FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse< DocumentDirectories > GetPA3DocumentsWithHttpInfo (string path)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new FactSet.AnalyticsAPI.Engines.v2.Client.ApiException(400, "Missing required parameter 'path' when calling DocumentsApi->GetPA3Documents");

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

            if (path != null)
                requestOptions.PathParameters.Add("path", FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.ParameterToString(path)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = this.Client.Get< DocumentDirectories >("/analytics/lookups/v2/engines/pa/documents/{path}", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetPA3Documents", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        /// Get PA3 documents and sub-directories in a directory This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>Task of DocumentDirectories</returns>
        public async System.Threading.Tasks.Task<DocumentDirectories> GetPA3DocumentsAsync (string path)
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories> localVarResponse = await GetPA3DocumentsAsyncWithHttpInfo(path);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get PA3 documents and sub-directories in a directory This endpoint looks up all PA3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents and sub-directories in</param>
        /// <returns>Task of ApiResponse (DocumentDirectories)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories>> GetPA3DocumentsAsyncWithHttpInfo (string path)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new FactSet.AnalyticsAPI.Engines.v2.Client.ApiException(400, "Missing required parameter 'path' when calling DocumentsApi->GetPA3Documents");


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
            
            if (path != null)
                requestOptions.PathParameters.Add("path", FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.ParameterToString(path)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = await this.AsynchronousClient.GetAsync<DocumentDirectories>("/analytics/lookups/v2/engines/pa/documents/{path}", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetPA3Documents", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>DocumentDirectories</returns>
        public DocumentDirectories GetSPAR3Documents (string path)
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories> localVarResponse = GetSPAR3DocumentsWithHttpInfo(path);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>ApiResponse of DocumentDirectories</returns>
        public FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse< DocumentDirectories > GetSPAR3DocumentsWithHttpInfo (string path)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new FactSet.AnalyticsAPI.Engines.v2.Client.ApiException(400, "Missing required parameter 'path' when calling DocumentsApi->GetSPAR3Documents");

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

            if (path != null)
                requestOptions.PathParameters.Add("path", FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.ParameterToString(path)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = this.Client.Get< DocumentDirectories >("/analytics/lookups/v2/engines/spar/documents/{path}", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetSPAR3Documents", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of DocumentDirectories</returns>
        public async System.Threading.Tasks.Task<DocumentDirectories> GetSPAR3DocumentsAsync (string path)
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories> localVarResponse = await GetSPAR3DocumentsAsyncWithHttpInfo(path);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets SPAR3 documents and sub-directories in a directory This endpoint looks up all SPAR3 documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of ApiResponse (DocumentDirectories)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories>> GetSPAR3DocumentsAsyncWithHttpInfo (string path)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new FactSet.AnalyticsAPI.Engines.v2.Client.ApiException(400, "Missing required parameter 'path' when calling DocumentsApi->GetSPAR3Documents");


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
            
            if (path != null)
                requestOptions.PathParameters.Add("path", FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.ParameterToString(path)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = await this.AsynchronousClient.GetAsync<DocumentDirectories>("/analytics/lookups/v2/engines/spar/documents/{path}", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetSPAR3Documents", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        /// Get Vault documents and sub-directories in a directory This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>DocumentDirectories</returns>
        public DocumentDirectories GetVaultDocuments (string path)
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories> localVarResponse = GetVaultDocumentsWithHttpInfo(path);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get Vault documents and sub-directories in a directory This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>ApiResponse of DocumentDirectories</returns>
        public FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse< DocumentDirectories > GetVaultDocumentsWithHttpInfo (string path)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new FactSet.AnalyticsAPI.Engines.v2.Client.ApiException(400, "Missing required parameter 'path' when calling DocumentsApi->GetVaultDocuments");

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

            if (path != null)
                requestOptions.PathParameters.Add("path", FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.ParameterToString(path)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = this.Client.Get< DocumentDirectories >("/analytics/lookups/v2/engines/vault/documents/{path}", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetVaultDocuments", response);
                if (exception != null) throw exception;
            }

            return response;
        }

        /// <summary>
        /// Get Vault documents and sub-directories in a directory This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of DocumentDirectories</returns>
        public async System.Threading.Tasks.Task<DocumentDirectories> GetVaultDocumentsAsync (string path)
        {
             FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories> localVarResponse = await GetVaultDocumentsAsyncWithHttpInfo(path);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get Vault documents and sub-directories in a directory This endpoint looks up all Vault documents and sub-directories in a given directory.
        /// </summary>
        /// <exception cref="FactSet.AnalyticsAPI.Engines.v2.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="path">The directory to get the documents in</param>
        /// <returns>Task of ApiResponse (DocumentDirectories)</returns>
        public async System.Threading.Tasks.Task<FactSet.AnalyticsAPI.Engines.v2.Client.ApiResponse<DocumentDirectories>> GetVaultDocumentsAsyncWithHttpInfo (string path)
        {
            // verify the required parameter 'path' is set
            if (path == null)
                throw new FactSet.AnalyticsAPI.Engines.v2.Client.ApiException(400, "Missing required parameter 'path' when calling DocumentsApi->GetVaultDocuments");


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
            
            if (path != null)
                requestOptions.PathParameters.Add("path", FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.ParameterToString(path)); // path parameter

            // authentication (Basic) required
            // http basic authentication required
            if (!String.IsNullOrEmpty(this.Configuration.Username) || !String.IsNullOrEmpty(this.Configuration.Password))
            {
                requestOptions.HeaderParameters.Add("Authorization", "Basic " + FactSet.AnalyticsAPI.Engines.v2.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request

            var response = await this.AsynchronousClient.GetAsync<DocumentDirectories>("/analytics/lookups/v2/engines/vault/documents/{path}", requestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("GetVaultDocuments", response);
                if (exception != null) throw exception;
            }

            return response;
        }

    }
}
