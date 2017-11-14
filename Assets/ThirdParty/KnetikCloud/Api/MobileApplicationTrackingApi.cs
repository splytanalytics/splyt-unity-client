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
    public interface IMobileApplicationTrackingApi
    {
        
        /// <summary>
        /// Submit mobile application tracking data for Tune applications 
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Tune campaign tracking information</param>
        void SubmitTuneRequest(string customerId, DataCollectorTuneRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MobileApplicationTrackingApi : IMobileApplicationTrackingApi
    {
        private readonly KnetikCoroutine mSubmitTuneRequestCoroutine;
        private DateTime mSubmitTuneRequestStartTime;
        private string mSubmitTuneRequestPath;

        public delegate void SubmitTuneRequestCompleteDelegate();
        public SubmitTuneRequestCompleteDelegate SubmitTuneRequestComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileApplicationTrackingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MobileApplicationTrackingApi()
        {
            mSubmitTuneRequestCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Submit mobile application tracking data for Tune applications 
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Tune campaign tracking information</param>
        public void SubmitTuneRequest(string customerId, DataCollectorTuneRequest request)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling SubmitTuneRequest");
            }
            
            mSubmitTuneRequestPath = "/v2/tune";
            if (!string.IsNullOrEmpty(mSubmitTuneRequestPath))
            {
                mSubmitTuneRequestPath = mSubmitTuneRequestPath.Replace("{format}", "json");
            }
            
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

            mSubmitTuneRequestStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSubmitTuneRequestStartTime, mSubmitTuneRequestPath, "Sending server request...");

            // make the HTTP request
            mSubmitTuneRequestCoroutine.ResponseReceived += SubmitTuneRequestCallback;
            mSubmitTuneRequestCoroutine.Start(mSubmitTuneRequestPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SubmitTuneRequestCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SubmitTuneRequest: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SubmitTuneRequest: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSubmitTuneRequestStartTime, mSubmitTuneRequestPath, "Response received successfully.");
            if (SubmitTuneRequestComplete != null)
            {
                SubmitTuneRequestComplete();
            }
        }

    }
}
