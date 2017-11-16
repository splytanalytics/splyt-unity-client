# com.knetikcloud..UsersApi

All URIs are relative to *https://api.knetik.io*

Method | HTTP request | Description
------------- | ------------- | -------------
[**NewUser**](UsersApi.md#newuser) | **POST** /v2/users | Submit a new user event
[**UpdateUserState**](UsersApi.md#updateuserstate) | **PUT** /v2/users/{id} | Updates the entity state for the given user


<a name="newuser"></a>
# **NewUser**
> void NewUser (string customerId, DataCollectorNewUserRequest request, bool? _checked)

Submit a new user event

Declares to the Knetik.io platform that the user is new at the given point in time. If the 'checked' parameter is provided and set to 'true', however, the current state of the user in the Knetik.io platform is examined to determine if the user was previously declared as new and, if so, the user information is not updated in the Knetik.io platform.

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class NewUserExample
    {
        public void main()
        {
            
            var apiInstance = new UsersApi();
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorNewUserRequest(); // DataCollectorNewUserRequest | New user information (optional) 
            var _checked = true;  // bool? | Flag indicating whether the user state should be checked before updating the state in the Knetik.io platform (optional)  (default to false)

            try
            {
                // Submit a new user event
                apiInstance.NewUser(customerId, request, _checked);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.NewUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorNewUserRequest**](DataCollectorNewUserRequest.md)| New user information | [optional] 
 **_checked** | **bool?**| Flag indicating whether the user state should be checked before updating the state in the Knetik.io platform | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateuserstate"></a>
# **UpdateUserState**
> void UpdateUserState (string id, string customerId, DataCollectorUpdateUserStateRequest request)

Updates the entity state for the given user

### Example
```csharp
using System;
using System.Diagnostics;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace Example
{
    public class UpdateUserStateExample
    {
        public void main()
        {
            
            var apiInstance = new UsersApi();
            var id = id_example;  // string | ID of the user for whom state is being updated
            var customerId = customerId_example;  // string | customerId
            var request = new DataCollectorUpdateUserStateRequest(); // DataCollectorUpdateUserStateRequest | Updated user state information (optional) 

            try
            {
                // Updates the entity state for the given user
                apiInstance.UpdateUserState(id, customerId, request);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.UpdateUserState: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| ID of the user for whom state is being updated | 
 **customerId** | **string**| customerId | 
 **request** | [**DataCollectorUpdateUserStateRequest**](DataCollectorUpdateUserStateRequest.md)| Updated user state information | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

