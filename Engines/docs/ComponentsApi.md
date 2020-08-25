# FactSet.AnalyticsAPI.Engines.Api.ComponentsApi

All URIs are relative to *https://api.factset.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetPAComponentById**](ComponentsApi.md#getpacomponentbyid) | **GET** /analytics/lookups/v2/engines/pa/components/{id} | Get PA component by id
[**GetPAComponents**](ComponentsApi.md#getpacomponents) | **GET** /analytics/lookups/v2/engines/pa/components | Get PA components
[**GetSPARComponents**](ComponentsApi.md#getsparcomponents) | **GET** /analytics/lookups/v2/engines/spar/components | Get SPAR components
[**GetVaultComponentById**](ComponentsApi.md#getvaultcomponentbyid) | **GET** /analytics/lookups/v2/engines/vault/components/{id} | Get Vault component by id
[**GetVaultComponents**](ComponentsApi.md#getvaultcomponents) | **GET** /analytics/lookups/v2/engines/vault/components | Get Vault components


<a name="getpacomponentbyid"></a>
# **GetPAComponentById**
> PAComponent GetPAComponentById (string id)

Get PA component by id

This endpoint returns the default settings of a PA component.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetPAComponentByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new ComponentsApi(config);
            var id = id_example;  // string | Unique identifier for a PA component

            try
            {
                // Get PA component by id
                PAComponent result = apiInstance.GetPAComponentById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComponentsApi.GetPAComponentById: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Unique identifier for a PA component | 

### Return type

[**PAComponent**](PAComponent.md)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Expected response, returns the default settings of a PA component. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **400** | Invalid PA component id. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **401** | Missing or invalid authentication. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **403** | User is forbidden with current credentials |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **404** | Component not found. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **406** | Unsupported Accept header. Header needs to be set to application/json. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getpacomponents"></a>
# **GetPAComponents**
> Dictionary&lt;string, ComponentSummary&gt; GetPAComponents (string document)

Get PA components

This endpoint returns the list of PA components in a given PA document.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetPAComponentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new ComponentsApi(config);
            var document = document_example;  // string | Document Name

            try
            {
                // Get PA components
                Dictionary<string, ComponentSummary> result = apiInstance.GetPAComponents(document);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComponentsApi.GetPAComponents: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **document** | **string**| Document Name | 

### Return type

[**Dictionary&lt;string, ComponentSummary&gt;**](ComponentSummary.md)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Expected response, returns a list of PA components. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **400** | Invalid query parameter provided or Invalid PA document name. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **401** | Missing or invalid authentication. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **403** | User is forbidden with current credentials |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **404** | Document not found. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **406** | Unsupported Accept header. Header needs to be set to application/json. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsparcomponents"></a>
# **GetSPARComponents**
> Dictionary&lt;string, ComponentSummary&gt; GetSPARComponents (string document)

Get SPAR components

This endpoint returns the list of SPAR components in a given SPAR document.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetSPARComponentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new ComponentsApi(config);
            var document = document_example;  // string | Document Name

            try
            {
                // Get SPAR components
                Dictionary<string, ComponentSummary> result = apiInstance.GetSPARComponents(document);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComponentsApi.GetSPARComponents: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **document** | **string**| Document Name | 

### Return type

[**Dictionary&lt;string, ComponentSummary&gt;**](ComponentSummary.md)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Expected response, returns a list of SPAR components. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **400** | Invalid query parameter provided or Invalid SPAR document name. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **401** | Missing or invalid authentication. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **403** | User is forbidden with current credentials |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **404** | SPAR Document not found. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **406** | Unsupported Accept header. Header needs to be set to application/json. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getvaultcomponentbyid"></a>
# **GetVaultComponentById**
> VaultComponent GetVaultComponentById (string id)

Get Vault component by id

This endpoint returns the default settings of a Vault component.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetVaultComponentByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new ComponentsApi(config);
            var id = id_example;  // string | Unique identifier for a vault component

            try
            {
                // Get Vault component by id
                VaultComponent result = apiInstance.GetVaultComponentById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComponentsApi.GetVaultComponentById: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Unique identifier for a vault component | 

### Return type

[**VaultComponent**](VaultComponent.md)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Expected response, returns the default settings of a Vault component. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **400** | Invalid Vault component id. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **401** | Missing or invalid authentication. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **403** | User is forbidden with current credentials |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **404** | Vault Component not found. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **406** | Unsupported Accept header. Header needs to be set to application/json. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getvaultcomponents"></a>
# **GetVaultComponents**
> Dictionary&lt;string, ComponentSummary&gt; GetVaultComponents (string document)

Get Vault components

This endpoint returns the list of Vault components in a given Vault document.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetVaultComponentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new ComponentsApi(config);
            var document = document_example;  // string | Document Name

            try
            {
                // Get Vault components
                Dictionary<string, ComponentSummary> result = apiInstance.GetVaultComponents(document);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ComponentsApi.GetVaultComponents: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **document** | **string**| Document Name | 

### Return type

[**Dictionary&lt;string, ComponentSummary&gt;**](ComponentSummary.md)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Expected response, returns a list of Vault components. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **400** | Invalid query parameter provided or invalid Vault document name. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **401** | Missing or invalid authentication. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **403** | User is forbidden with current credentials |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **404** | Vault Document not found. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **406** | Unsupported Accept header. Header needs to be set to application/json. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

