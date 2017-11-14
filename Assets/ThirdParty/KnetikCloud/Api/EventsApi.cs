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
    public interface IEventsApi
    {
        
        /// <summary>
        /// Creates a single event (a transaction with no duration) 
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Similar to transactions, the details of that event</param>
        void CreateEvent(string customerId, NewEventRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class EventsApi : IEventsApi
    {
        private readonly KnetikCoroutine mCreateEventCoroutine;
        private DateTime mCreateEventStartTime;
        private string mCreateEventPath;

        public delegate void CreateEventCompleteDelegate();
        public CreateEventCompleteDelegate CreateEventComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public EventsApi()
        {
            mCreateEventCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Creates a single event (a transaction with no duration) 
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Similar to transactions, the details of that event</param>
        public void CreateEvent(string customerId, NewEventRequest request)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling CreateEvent");
            }
            
            mCreateEventPath = "/v2/events";
            if (!string.IsNullOrEmpty(mCreateEventPath))
            {
                mCreateEventPath = mCreateEventPath.Replace("{format}", "json");
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

            mCreateEventStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateEventStartTime, mCreateEventPath, "Sending server request...");

            // make the HTTP request
            mCreateEventCoroutine.ResponseReceived += CreateEventCallback;
            mCreateEventCoroutine.Start(mCreateEventPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateEventCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateEvent: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateEvent: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mCreateEventStartTime, mCreateEventPath, "Response received successfully.");
            if (CreateEventComplete != null)
            {
                CreateEventComplete();
            }
        }

    }
}
