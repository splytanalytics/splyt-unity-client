# com.knetikcloud..DebuggingApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DisableDebugger**](DebuggingApi.md#disabledebugger) | **DELETE** /v2/_debug/{customerId} | Disable debugging via Redis
[**EnableDebugger**](DebuggingApi.md#enabledebugger) | **POST** /v2/_debug/{customerId} | Enable debugging via Redis


<a name="disabledebugger"></a>
# **DisableDebugger**
> void DisableDebugger (string customerId)

Disable debugging via Redis

Forces debugging to be disabled for the customer

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class DisableDebuggerExample
    {
        public void main()
        {
            
            var apiInstance = new DebuggingApi();
            var customerId = customerId_example;  // string | ID of the customer

            try
            {
                // Disable debugging via Redis
                apiInstance.DisableDebugger(customerId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DebuggingApi.DisableDebugger: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| ID of the customer | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="enabledebugger"></a>
# **EnableDebugger**
> void EnableDebugger (string customerId)

Enable debugging via Redis

Debugging is only enabled for a limited period of time (default is one hour)

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class EnableDebuggerExample
    {
        public void main()
        {
            
            var apiInstance = new DebuggingApi();
            var customerId = customerId_example;  // string | ID of the customer

            try
            {
                // Enable debugging via Redis
                apiInstance.EnableDebugger(customerId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DebuggingApi.EnableDebugger: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| ID of the customer | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

