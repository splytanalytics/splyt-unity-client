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
    public interface IBatchApi
    {
        List<BatchRequestResult> SubmitBatchData { get; }

        
        /// <summary>
        /// Submit a batch of requests as an array of input models For this to work, you will need to specify the value of the request_type field of each element in the list, which indicates the type of the element. For example, to submit a batch containing a DataCollectorNewUserRequest you would specify the value &#x60;newUser&#x60; as the request_type for your DataCollectorNewUserRequest element. Convention is DataCollectorSomeTypeRequest -&gt; someType (DataCollectorNewUserRequest -&gt; newUser, DataCollectorNewDeviceRequest -&gt; newDevice, etc). If any invalid requests are detected in the batch, a HTTP 207 (Multi-Status) will be returned and the body will contain the status of each of the requests, in the order in which they were submitted, with detailed error messages and the JSON of the request returned for any invalid requests.
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="batchRequest">The batch of requests to submit</param>
        void SubmitBatch(string customerId, DataCollectorBatchRequest batchRequest);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BatchApi : IBatchApi
    {
        private readonly KnetikCoroutine mSubmitBatchCoroutine;
        private DateTime mSubmitBatchStartTime;
        private string mSubmitBatchPath;

        public List<BatchRequestResult> SubmitBatchData { get; private set; }
        public delegate void SubmitBatchCompleteDelegate(List<BatchRequestResult> response);
        public SubmitBatchCompleteDelegate SubmitBatchComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BatchApi()
        {
            mSubmitBatchCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Submit a batch of requests as an array of input models For this to work, you will need to specify the value of the request_type field of each element in the list, which indicates the type of the element. For example, to submit a batch containing a DataCollectorNewUserRequest you would specify the value &#x60;newUser&#x60; as the request_type for your DataCollectorNewUserRequest element. Convention is DataCollectorSomeTypeRequest -&gt; someType (DataCollectorNewUserRequest -&gt; newUser, DataCollectorNewDeviceRequest -&gt; newDevice, etc). If any invalid requests are detected in the batch, a HTTP 207 (Multi-Status) will be returned and the body will contain the status of each of the requests, in the order in which they were submitted, with detailed error messages and the JSON of the request returned for any invalid requests.
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="batchRequest">The batch of requests to submit</param>
        public void SubmitBatch(string customerId, DataCollectorBatchRequest batchRequest)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling SubmitBatch");
            }
            
            mSubmitBatchPath = "/v2/batch";
            if (!string.IsNullOrEmpty(mSubmitBatchPath))
            {
                mSubmitBatchPath = mSubmitBatchPath.Replace("{format}", "json");
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

            postBody = KnetikClient.DefaultClient.Serialize(batchRequest); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mSubmitBatchStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSubmitBatchStartTime, mSubmitBatchPath, "Sending server request...");

            // make the HTTP request
            mSubmitBatchCoroutine.ResponseReceived += SubmitBatchCallback;
            mSubmitBatchCoroutine.Start(mSubmitBatchPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SubmitBatchCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SubmitBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SubmitBatch: " + response.ErrorMessage, response.ErrorMessage);
            }

            SubmitBatchData = (List<BatchRequestResult>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<BatchRequestResult>), response.Headers);
            KnetikLogger.LogResponse(mSubmitBatchStartTime, mSubmitBatchPath, string.Format("Response received successfully:\n{0}", SubmitBatchData.ToString()));

            if (SubmitBatchComplete != null)
            {
                SubmitBatchComplete(SubmitBatchData);
            }
        }

    }
}
