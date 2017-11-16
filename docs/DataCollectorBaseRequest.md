# com.knetikcloud.Model.DataCollectorBaseRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DeviceId** | **string** | Unique ID of the device triggering the event | [optional] 
**EventProperties** | **Object** | A key/value list of properties for this event. Values can be numerical, strings or booleans, proper typing matters (quoted vs unquoted) | [optional] 
**EventTimestamp** | **long?** | Epoch timestamp &lt;i&gt;in milliseconds&lt;/i&gt; of when event itself occurred | 
**RequestType** | **string** | Specifies the canonical model name of the request. Ex: DataCollectorNewUserRequest -&gt; newUser, NewEventRequest -&gt; newEvent,e tc | 
**SendTimestamp** | **long?** | Epoch timestamp &lt;i&gt;in milliseconds&lt;/i&gt; of when event was sent to the API | 
**UserId** | **string** | Unique ID of the user triggering the event | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

