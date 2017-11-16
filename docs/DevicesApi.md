# com.knetikcloud..DevicesApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**NewDevice**](DevicesApi.md#newdevice) | **POST** /v2/devices | Submit a new device event
[**UpdateDeviceState**](DevicesApi.md#updatedevicestate) | **PUT** /v2/devices/{id} | Updates the state parameters for the given device


<a name="newdevice"></a>
# **NewDevice**
> void NewDevice (string customerId, DataCollectorNewDeviceRequest request, bool? _checked)

Submit a new device event

Declares to the Knetik.io platform that a device is new at the given point in time. If the 'checked' parameter is provided and set to 'true', however, the current state of the device in the Knetik.io platform is examined to determine if the device was previously declared as new and, if so, the device information is not updated in the Knetik.io platform.

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class NewDeviceExample
    {
        public void main()
        {
            
            var apiInstance = new DevicesApi();
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorNewDeviceRequest(); // DataCollectorNewDeviceRequest | New device information (optional) 
            var _checked = true;  // bool? | Flag indicating whether the device state should be checked before updating the state in the Knetik.io platform (optional)  (default to false)

            try
            {
                // Submit a new device event
                apiInstance.NewDevice(customerId, request, _checked);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DevicesApi.NewDevice: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorNewDeviceRequest**](DataCollectorNewDeviceRequest.md)| New device information | [optional] 
 **_checked** | **bool?**| Flag indicating whether the device state should be checked before updating the state in the Knetik.io platform | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatedevicestate"></a>
# **UpdateDeviceState**
> void UpdateDeviceState (string id, string customerId, DataCollectorUpdateDeviceStateRequest request)

Updates the state parameters for the given device

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class UpdateDeviceStateExample
    {
        public void main()
        {
            
            var apiInstance = new DevicesApi();
            var id = id_example;  // string | ID of the device for which state information is being updated
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorUpdateDeviceStateRequest(); // DataCollectorUpdateDeviceStateRequest | Updated device state information (optional) 

            try
            {
                // Updates the state parameters for the given device
                apiInstance.UpdateDeviceState(id, customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DevicesApi.UpdateDeviceState: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| ID of the device for which state information is being updated | 
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorUpdateDeviceStateRequest**](DataCollectorUpdateDeviceStateRequest.md)| Updated device state information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

