# FactSet.AnalyticsAPI.Engines.Api.UtilityApi

All URIs are relative to *https://api.factset.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetByUrl**](UtilityApi.md#getbyurl) | **GET** {url} | Url of the GET endpoint 

<a name="getbyurl"></a>
# **GetByUrl**
> string GetByUrl (string url)

Get by Url

This function can be used to fetch data from any GET endpoint.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FactSet.AnalyticsAPI.Engines.Api;
using FactSet.AnalyticsAPI.Engines.Client;
using FactSet.AnalyticsAPI.Engines.Model;

namespace Example
{
    public class GetByUrlExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.factset.com";
            // Configure HTTP basic authorization: Basic
            Configuration.Default.Username = "YOUR_USERNAME";
            Configuration.Default.Password = "YOUR_PASSWORD";

            var apiInstance = new UtilityApi(Configuration.Default);
            var url = "url_example";  // string | Url of the GET endpoint

            try
            {
                // Get by url
                string result = apiInstance.GetByUrl(url);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UtilityApi.GetByUrl: " + e.Message );
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
 **id** | **string**| Url of the GET endpoint | 

### Return type

**string**

### Authorization

[Basic](../README.md#Basic)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
**200** | Expected response once the request is successful. |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |
**400** | Invalid identifier provided. |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |
**401** | Missing or invalid authentication. |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |
**403** | User is forbidden with current credentials |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |
**406** | Unsupported Accept header. Header needs to be set to application/json. |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |
**500** | Server error. Log the X-DataDirect-Request-Key header to assist in troubleshooting. |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |
**503** | Request timed out. Retry the request in sometime. |  * X-FactSet-Api-Request-Key - Key to uniquely identify an Analytics API request. Only available after successful authentication. <br>  * X-DataDirect-Request-Key - FactSet's request key header. <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
