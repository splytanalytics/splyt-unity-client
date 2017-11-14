using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
using UnityEngine;

using Object = System.Object;
using Version = com.knetikcloud.Model.Version;


namespace com.knetikcloud.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDevicesApi
    {
        
        /// <summary>
        /// Submit a new device event Declares to the Knetik.io platform that a device is new at the given point in time. If the &#39;checked&#39; parameter is provided and set to &#39;true&#39;, however, the current state of the device in the Knetik.io platform is examined to determine if the device was previously declared as new and, if so, the device information is not updated in the Knetik.io platform.
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">New device information</param>
        /// <param name="_checked">Flag indicating whether the device state should be checked before updating the state in the Knetik.io platform</param>
        void NewDevice(string customerId, DataCollectorNewDeviceRequest request, bool? _checked);

        /// <summary>
        /// Updates the state parameters for the given device 
        /// </summary>
        /// <param name="id">ID of the device for which state information is being updated</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Updated device state information</param>
        void UpdateDeviceState(string id, string customerId, DataCollectorUpdateDeviceStateRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DevicesApi : IDevicesApi
    {
        private readonly KnetikCoroutine mNewDeviceCoroutine;
        private DateTime mNewDeviceStartTime;
        private string mNewDevicePath;
        private readonly KnetikCoroutine mUpdateDeviceStateCoroutine;
        private DateTime mUpdateDeviceStateStartTime;
        private string mUpdateDeviceStatePath;

        public delegate void NewDeviceCompleteDelegate();
        public NewDeviceCompleteDelegate NewDeviceComplete;

        public delegate void UpdateDeviceStateCompleteDelegate();
        public UpdateDeviceStateCompleteDelegate UpdateDeviceStateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DevicesApi()
        {
            mNewDeviceCoroutine = new KnetikCoroutine();
            mUpdateDeviceStateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Submit a new device event Declares to the Knetik.io platform that a device is new at the given point in time. If the &#39;checked&#39; parameter is provided and set to &#39;true&#39;, however, the current state of the device in the Knetik.io platform is examined to determine if the device was previously declared as new and, if so, the device information is not updated in the Knetik.io platform.
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">New device information</param>
        /// <param name="_checked">Flag indicating whether the device state should be checked before updating the state in the Knetik.io platform</param>
        public void NewDevice(string customerId, DataCollectorNewDeviceRequest request, bool? _checked)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling NewDevice");
            }
            
            mNewDevicePath = "/v2/devices";
            if (!string.IsNullOrEmpty(mNewDevicePath))
            {
                mNewDevicePath = mNewDevicePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (_checked != null)
            {
                queryParams.Add("checked", KnetikClient.DefaultClient.ParameterToString(_checked));
            }

            if (customerId != null)
            {
                queryParams.Add("customerId", KnetikClient.DefaultClient.ParameterToString(customerId));
            }

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mNewDeviceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mNewDeviceStartTime, mNewDevicePath, "Sending server request...");

            // make the HTTP request
            mNewDeviceCoroutine.ResponseReceived += NewDeviceCallback;
            mNewDeviceCoroutine.Start(mNewDevicePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void NewDeviceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling NewDevice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling NewDevice: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mNewDeviceStartTime, mNewDevicePath, "Response received successfully.");
            if (NewDeviceComplete != null)
            {
                NewDeviceComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the state parameters for the given device 
        /// </summary>
        /// <param name="id">ID of the device for which state information is being updated</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Updated device state information</param>
        public void UpdateDeviceState(string id, string customerId, DataCollectorUpdateDeviceStateRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateDeviceState");
            }
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling UpdateDeviceState");
            }
            
            mUpdateDeviceStatePath = "/v2/devices/{id}";
            if (!string.IsNullOrEmpty(mUpdateDeviceStatePath))
            {
                mUpdateDeviceStatePath = mUpdateDeviceStatePath.Replace("{format}", "json");
            }
            mUpdateDeviceStatePath = mUpdateDeviceStatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (customerId != null)
            {
                queryParams.Add("customerId", KnetikClient.DefaultClient.ParameterToString(customerId));
            }

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mUpdateDeviceStateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateDeviceStateStartTime, mUpdateDeviceStatePath, "Sending server request...");

            // make the HTTP request
            mUpdateDeviceStateCoroutine.ResponseReceived += UpdateDeviceStateCallback;
            mUpdateDeviceStateCoroutine.Start(mUpdateDeviceStatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateDeviceStateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateDeviceState: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateDeviceState: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateDeviceStateStartTime, mUpdateDeviceStatePath, "Response received successfully.");
            if (UpdateDeviceStateComplete != null)
            {
                UpdateDeviceStateComplete();
            }
        }

    }
}
