# FactSet.AnalyticsAPI.Engines.Api.VaultCalculationsApi

All URIs are relative to *https://api.factset.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CancelVaultCalculationById**](VaultCalculationsApi.md#cancelvaultcalculationbyid) | **DELETE** /analytics/engines/vault/v2/calculations/{id} | Cancel Vault calculation by id
[**GetVaultCalculationById**](VaultCalculationsApi.md#getvaultcalculationbyid) | **GET** /analytics/engines/vault/v2/calculations/{id} | Get Vault calculation by id
[**RunVaultCalculation**](VaultCalculationsApi.md#runvaultcalculation) | **POST** /analytics/engines/vault/v2/calculations | Run Vault Calculation


<a name="cancelvaultcalculationbyid"></a>
# **CancelVaultCalculationById**
> void CancelVaultCalculationById (string id)

Cancel Vault calculation by id

This is the endpoint to cancel a previously submitted calculation.  Instead of doing a GET on the polling URL, cancel the request by doing a DELETE.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class CancelVaultCalculationByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new VaultCalculationsApi(config);
            var id = id_example;  // string | from url, provided from the location header in the Run Calculation endpoint

            try
            {
                // Cancel Vault calculation by id
                apiInstance.CancelVaultCalculationById(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VaultCalculationsApi.CancelVaultCalculationById: " + e.Message );
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
 **id** | **string**| from url, provided from the location header in the Run Calculation endpoint | 

### Return type

void (empty response body)

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Expected response, calculation was canceled successfully. |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **400** | Invalid identifier provided. |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **401** | Missing or invalid authentication. |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |
| **403** | User is forbidden with current credentials |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **404** | There was no request for the calculation identifier provided, or the request was already canceled for the provided identifier. |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getvaultcalculationbyid"></a>
# **GetVaultCalculationById**
> Object GetVaultCalculationById (string id)

Get Vault calculation by id

This is the endpoint to check on the progress of a previously requested calculation.  If the calculation has finished computing, the body of the response will contain the requested document in JSON.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetVaultCalculationByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new VaultCalculationsApi(config);
            var id = id_example;  // string | from url, provided from the location header in the Run Calculation endpoint

            try
            {
                // Get Vault calculation by id
                Object result = apiInstance.GetVaultCalculationById(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VaultCalculationsApi.GetVaultCalculationById: " + e.Message );
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
 **id** | **string**| from url, provided from the location header in the Run Calculation endpoint | 

### Return type

**Object**

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Expected response returned if the calculation is not yet completed. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **200** | Expected response once calculation is completed, returns JSON in the format specified in the Run Calculations endpoint. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **400** | Invalid identifier provided. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **401** | Missing or invalid authentication. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |
| **403** | User is forbidden with current credentials |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **404** | Calculation was already returned, provided id was not a requested calculation, or the calculation was cancelled |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="runvaultcalculation"></a>
# **RunVaultCalculation**
> Object RunVaultCalculation (VaultCalculationParameters vaultCalculationParameters = null)

Run Vault Calculation

This endpoint runs the Vault calculation specified in the POST body parameters.  It must be used first before polling or cancelling endpoints.  A successful response will contain the URL to poll for the result of the calculation.    Remarks:    *   Start and and end date must be within the configuration's min and max date range

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class RunVaultCalculationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            var apiInstance = new VaultCalculationsApi(config);
            var vaultCalculationParameters = new VaultCalculationParameters(); // VaultCalculationParameters |  (optional) 

            try
            {
                // Run Vault Calculation
                Object result = apiInstance.RunVaultCalculation(vaultCalculationParameters);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VaultCalculationsApi.RunVaultCalculation: " + e.Message );
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
 **vaultCalculationParameters** | [**VaultCalculationParameters**](VaultCalculationParameters.md)|  | [optional] 

### Return type

**Object**

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Expected response, contains the poll URL in the Location header. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **201** | Expected response if calculation is completed within 30 seconds, returns JSON in the format specified in the Run Calculations endpoint. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **400** | Invalid POST body. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **401** | Missing or invalid authentication. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |
| **403** | User is forbidden with current credentials |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **404** | One or more calculation settings were unavailable. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **415** | Missing/Invalid Content-Type header. Header needs to be set to application/json. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  |
| **429** | Rate limit reached. Cancel older requests using Cancel Calculation endpoint or wait for older requests to finish/expire. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-RateLimit-Limit - Number of allowed requests for the time window. <br>  * X-RateLimit-Remaining - Number of requests left for the time window. <br>  * X-RateLimit-Reset - Number of seconds remaining till rate limit resets. <br>  * Retry-After - Time to wait in seconds before making a new request as the rate limit has reached. <br>  |
| **500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |
| **503** | Request timed out. Retry the request in sometime. |  * Cache-Control - Standard HTTP header. Header will specify max-age in seconds. Polling can be adjusted based on the max-age value. <br>  * Content-Encoding - Standard HTTP header. Header value based on Accept-Encoding Request header. <br>  * Content-Type - Standard HTTP header. <br>  * Transfer-Encoding - Standard HTTP header. Header value will be set to Chunked if Accept-Encoding header is specified. <br>  * X-DataDirect-Request-Key - FactSet&#39;s request key header. <br>  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

