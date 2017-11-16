# com.knetikcloud..MobileApplicationTrackingApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SubmitTuneRequest**](MobileApplicationTrackingApi.md#submittunerequest) | **POST** /v2/tune | Submit mobile application tracking data for Tune applications


<a name="submittunerequest"></a>
# **SubmitTuneRequest**
> void SubmitTuneRequest (string customerId, DataCollectorTuneRequest request)

Submit mobile application tracking data for Tune applications

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class SubmitTuneRequestExample
    {
        public void main()
        {
            
            var apiInstance = new MobileApplicationTrackingApi();
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorTuneRequest(); // DataCollectorTuneRequest | Tune campaign tracking information (optional) 

            try
            {
                // Submit mobile application tracking data for Tune applications
                apiInstance.SubmitTuneRequest(customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MobileApplicationTrackingApi.SubmitTuneRequest: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorTuneRequest**](DataCollectorTuneRequest.md)| Tune campaign tracking information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

