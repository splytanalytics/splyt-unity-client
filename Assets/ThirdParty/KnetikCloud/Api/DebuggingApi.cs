using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Utils;
using UnityEngine;

using Object = System.Object;
using Version = com.knetikcloud.Model.Version;


namespace com.knetikcloud.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDebuggingApi
    {
        
        /// <summary>
        /// Disable debugging via Redis Forces debugging to be disabled for the customer
        /// </summary>
        /// <param name="customerId">ID of the customer</param>
        void DisableDebugger(string customerId);

        /// <summary>
        /// Enable debugging via Redis Debugging is only enabled for a limited period of time (default is one hour)
        /// </summary>
        /// <param name="customerId">ID of the customer</param>
        void EnableDebugger(string customerId);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DebuggingApi : IDebuggingApi
    {
        private readonly KnetikCoroutine mDisableDebuggerCoroutine;
        private DateTime mDisableDebuggerStartTime;
        private string mDisableDebuggerPath;
        private readonly KnetikCoroutine mEnableDebuggerCoroutine;
        private DateTime mEnableDebuggerStartTime;
        private string mEnableDebuggerPath;

        public delegate void DisableDebuggerCompleteDelegate();
        public DisableDebuggerCompleteDelegate DisableDebuggerComplete;

        public delegate void EnableDebuggerCompleteDelegate();
        public EnableDebuggerCompleteDelegate EnableDebuggerComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DebuggingApi()
        {
            mDisableDebuggerCoroutine = new KnetikCoroutine();
            mEnableDebuggerCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Disable debugging via Redis Forces debugging to be disabled for the customer
        /// </summary>
        /// <param name="customerId">ID of the customer</param>
        public void DisableDebugger(string customerId)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling DisableDebugger");
            }
            
            mDisableDebuggerPath = "/v2/_debug/{customerId}";
            if (!string.IsNullOrEmpty(mDisableDebuggerPath))
            {
                mDisableDebuggerPath = mDisableDebuggerPath.Replace("{format}", "json");
            }
            mDisableDebuggerPath = mDisableDebuggerPath.Replace("{" + "customerId" + "}", KnetikClient.DefaultClient.ParameterToString(customerId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mDisableDebuggerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDisableDebuggerStartTime, mDisableDebuggerPath, "Sending server request...");

            // make the HTTP request
            mDisableDebuggerCoroutine.ResponseReceived += DisableDebuggerCallback;
            mDisableDebuggerCoroutine.Start(mDisableDebuggerPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DisableDebuggerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DisableDebugger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DisableDebugger: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDisableDebuggerStartTime, mDisableDebuggerPath, "Response received successfully.");
            if (DisableDebuggerComplete != null)
            {
                DisableDebuggerComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Enable debugging via Redis Debugging is only enabled for a limited period of time (default is one hour)
        /// </summary>
        /// <param name="customerId">ID of the customer</param>
        public void EnableDebugger(string customerId)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling EnableDebugger");
            }
            
            mEnableDebuggerPath = "/v2/_debug/{customerId}";
            if (!string.IsNullOrEmpty(mEnableDebuggerPath))
            {
                mEnableDebuggerPath = mEnableDebuggerPath.Replace("{format}", "json");
            }
            mEnableDebuggerPath = mEnableDebuggerPath.Replace("{" + "customerId" + "}", KnetikClient.DefaultClient.ParameterToString(customerId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mEnableDebuggerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mEnableDebuggerStartTime, mEnableDebuggerPath, "Sending server request...");

            // make the HTTP request
            mEnableDebuggerCoroutine.ResponseReceived += EnableDebuggerCallback;
            mEnableDebuggerCoroutine.Start(mEnableDebuggerPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void EnableDebuggerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling EnableDebugger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling EnableDebugger: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mEnableDebuggerStartTime, mEnableDebuggerPath, "Response received successfully.");
            if (EnableDebuggerComplete != null)
            {
                EnableDebuggerComplete();
            }
        }

    }
}
