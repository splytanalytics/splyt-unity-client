# com.knetikcloud.Model.DataCollectorBeginTransactionRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Timeout** | **int?** | Timeout (in seconds) for the transaction | [optional] 
**TimeoutMode** | **string** | Timeout mode for the transaction. With TXN, the timeout is reset when an update is posted to the same transaction. With ANY, the timeout is reset when an update is posted for any transaction w/ the same user/device | [optional] 
**TransactionId** | **string** | Unique transaction ID | [optional] 
**Category** | **string** | The name/type of the transaction | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

