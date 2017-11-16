# com.knetikcloud..BatchApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SubmitBatch**](BatchApi.md#submitbatch) | **POST** /v2/batch | Submit a batch of requests as an array of input models


<a name="submitbatch"></a>
# **SubmitBatch**
> List<BatchRequestResult> SubmitBatch (string customerId, DataCollectorBatchRequest batchRequest)

Submit a batch of requests as an array of input models

For this to work, you will need to specify the value of the request_type field of each element in the list, which indicates the type of the element. For example, to submit a batch containing a DataCollectorNewUserRequest you would specify the value `newUser` as the request_type for your DataCollectorNewUserRequest element. Convention is DataCollectorSomeTypeRequest -> someType (DataCollectorNewUserRequest -> newUser, DataCollectorNewDeviceRequest -> newDevice, etc). If any invalid requests are detected in the batch, a HTTP 207 (Multi-Status) will be returned and the body will contain the status of each of the requests, in the order in which they were submitted, with detailed error messages and the JSON of the request returned for any invalid requests.

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class SubmitBatchExample
    {
        public void main()
        {
            
            var apiInstance = new BatchApi();
            var customerId = customerId_example;  // string | customerId
            var batchRequest = new DataCollectorBatchRequest(); // DataCollectorBatchRequest | The batch of requests to submit (optional) 

            try
            {
                // Submit a batch of requests as an array of input models
                List&lt;BatchRequestResult&gt; result = apiInstance.SubmitBatch(customerId, batchRequest);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BatchApi.SubmitBatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **batchRequest** | [**DataCollectorBatchRequest**](DataCollectorBatchRequest.md)| The batch of requests to submit | [optional] 

### Return type

[**List<BatchRequestResult>**](BatchRequestResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

