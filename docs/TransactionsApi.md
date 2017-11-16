# com.knetikcloud..TransactionsApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BeginTransaction**](TransactionsApi.md#begintransaction) | **POST** /v2/transactions | Begins a new transaction
[**EndTransaction**](TransactionsApi.md#endtransaction) | **PUT** /v2/transactions/{id}/end | Ends the transaction
[**UpdateCollection**](TransactionsApi.md#updatecollection) | **POST** /v2/collections | Creates and finalizes a collection of transaction information
[**UpdateTransaction**](TransactionsApi.md#updatetransaction) | **PUT** /v2/transactions/{id} | Updates the progress for the given transaction


<a name="begintransaction"></a>
# **BeginTransaction**
> void BeginTransaction (string customerId, DataCollectorBeginTransactionRequest request)

Begins a new transaction

Use the event properties to describe the initial state of the transaction

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class BeginTransactionExample
    {
        public void main()
        {
            
            var apiInstance = new TransactionsApi();
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorBeginTransactionRequest(); // DataCollectorBeginTransactionRequest | Transaction initiation information (optional) 

            try
            {
                // Begins a new transaction
                apiInstance.BeginTransaction(customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionsApi.BeginTransaction: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorBeginTransactionRequest**](DataCollectorBeginTransactionRequest.md)| Transaction initiation information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="endtransaction"></a>
# **EndTransaction**
> void EndTransaction (string id, string customerId, DataCollectorEndTransactionRequest request)

Ends the transaction

Submits final transaction state to Knetik.io

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class EndTransactionExample
    {
        public void main()
        {
            
            var apiInstance = new TransactionsApi();
            var id = id_example;  // string | Unique ID of the transaction being finalized
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorEndTransactionRequest(); // DataCollectorEndTransactionRequest | Transaction finalization information (optional) 

            try
            {
                // Ends the transaction
                apiInstance.EndTransaction(id, customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionsApi.EndTransaction: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Unique ID of the transaction being finalized | 
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorEndTransactionRequest**](DataCollectorEndTransactionRequest.md)| Transaction finalization information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecollection"></a>
# **UpdateCollection**
> void UpdateCollection (string customerId, DataCollectorUpdateCollectionRequest request)

Creates and finalizes a collection of transaction information

This operation basically encapsulates beginTransaction and endTransaction semantics into a single step and is used to update user balance information in Knetik.io

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class UpdateCollectionExample
    {
        public void main()
        {
            
            var apiInstance = new TransactionsApi();
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorUpdateCollectionRequest(); // DataCollectorUpdateCollectionRequest | Collection state information (optional) 

            try
            {
                // Creates and finalizes a collection of transaction information
                apiInstance.UpdateCollection(customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionsApi.UpdateCollection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorUpdateCollectionRequest**](DataCollectorUpdateCollectionRequest.md)| Collection state information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatetransaction"></a>
# **UpdateTransaction**
> void UpdateTransaction (string id, string customerId, DataCollectorUpdateTransactionRequest request)

Updates the progress for the given transaction

Use the event properties to update the state of the transaction

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class UpdateTransactionExample
    {
        public void main()
        {
            
            var apiInstance = new TransactionsApi();
            var id = id_example;  // string | Unique ID of the transaction being updated
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorUpdateTransactionRequest(); // DataCollectorUpdateTransactionRequest | Transaction progress information (optional) 

            try
            {
                // Updates the progress for the given transaction
                apiInstance.UpdateTransaction(id, customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransactionsApi.UpdateTransaction: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Unique ID of the transaction being updated | 
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorUpdateTransactionRequest**](DataCollectorUpdateTransactionRequest.md)| Transaction progress information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

