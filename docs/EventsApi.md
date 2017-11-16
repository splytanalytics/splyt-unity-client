# com.knetikcloud..EventsApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateEvent**](EventsApi.md#createevent) | **POST** /v2/events | Creates a single event (a transaction with no duration)


<a name="createevent"></a>
# **CreateEvent**
> void CreateEvent (string customerId, NewEventRequest request)

Creates a single event (a transaction with no duration)

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class CreateEventExample
    {
        public void main()
        {
            
            var apiInstance = new EventsApi();
            var customerId = customerId_example;  // string | customerId
            var request = new NewEventRequest(); // NewEventRequest | Similar to transactions, the details of that event (optional) 

            try
            {
                // Creates a single event (a transaction with no duration)
                apiInstance.CreateEvent(customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EventsApi.CreateEvent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **request** | [**NewEventRequest**](NewEventRequest.md)| Similar to transactions, the details of that event | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

