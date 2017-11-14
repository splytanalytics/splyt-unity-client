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
    public interface ITransactionsApi
    {
        
        /// <summary>
        /// Begins a new transaction Use the event properties to describe the initial state of the transaction
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Transaction initiation information</param>
        void BeginTransaction(string customerId, DataCollectorBeginTransactionRequest request);

        /// <summary>
        /// Ends the transaction Submits final transaction state to Knetik.io
        /// </summary>
        /// <param name="id">Unique ID of the transaction being finalized</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Transaction finalization information</param>
        void EndTransaction(string id, string customerId, DataCollectorEndTransactionRequest request);

        /// <summary>
        /// Creates and finalizes a collection of transaction information This operation basically encapsulates beginTransaction and endTransaction semantics into a single step and is used to update user balance information in Knetik.io
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Collection state information</param>
        void UpdateCollection(string customerId, DataCollectorUpdateCollectionRequest request);

        /// <summary>
        /// Updates the progress for the given transaction Use the event properties to update the state of the transaction
        /// </summary>
        /// <param name="id">Unique ID of the transaction being updated</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Transaction progress information</param>
        void UpdateTransaction(string id, string customerId, DataCollectorUpdateTransactionRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TransactionsApi : ITransactionsApi
    {
        private readonly KnetikCoroutine mBeginTransactionCoroutine;
        private DateTime mBeginTransactionStartTime;
        private string mBeginTransactionPath;
        private readonly KnetikCoroutine mEndTransactionCoroutine;
        private DateTime mEndTransactionStartTime;
        private string mEndTransactionPath;
        private readonly KnetikCoroutine mUpdateCollectionCoroutine;
        private DateTime mUpdateCollectionStartTime;
        private string mUpdateCollectionPath;
        private readonly KnetikCoroutine mUpdateTransactionCoroutine;
        private DateTime mUpdateTransactionStartTime;
        private string mUpdateTransactionPath;

        public delegate void BeginTransactionCompleteDelegate();
        public BeginTransactionCompleteDelegate BeginTransactionComplete;

        public delegate void EndTransactionCompleteDelegate();
        public EndTransactionCompleteDelegate EndTransactionComplete;

        public delegate void UpdateCollectionCompleteDelegate();
        public UpdateCollectionCompleteDelegate UpdateCollectionComplete;

        public delegate void UpdateTransactionCompleteDelegate();
        public UpdateTransactionCompleteDelegate UpdateTransactionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TransactionsApi()
        {
            mBeginTransactionCoroutine = new KnetikCoroutine();
            mEndTransactionCoroutine = new KnetikCoroutine();
            mUpdateCollectionCoroutine = new KnetikCoroutine();
            mUpdateTransactionCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Begins a new transaction Use the event properties to describe the initial state of the transaction
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Transaction initiation information</param>
        public void BeginTransaction(string customerId, DataCollectorBeginTransactionRequest request)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling BeginTransaction");
            }
            
            mBeginTransactionPath = "/v2/transactions";
            if (!string.IsNullOrEmpty(mBeginTransactionPath))
            {
                mBeginTransactionPath = mBeginTransactionPath.Replace("{format}", "json");
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

            mBeginTransactionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mBeginTransactionStartTime, mBeginTransactionPath, "Sending server request...");

            // make the HTTP request
            mBeginTransactionCoroutine.ResponseReceived += BeginTransactionCallback;
            mBeginTransactionCoroutine.Start(mBeginTransactionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void BeginTransactionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling BeginTransaction: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling BeginTransaction: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mBeginTransactionStartTime, mBeginTransactionPath, "Response received successfully.");
            if (BeginTransactionComplete != null)
            {
                BeginTransactionComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Ends the transaction Submits final transaction state to Knetik.io
        /// </summary>
        /// <param name="id">Unique ID of the transaction being finalized</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Transaction finalization information</param>
        public void EndTransaction(string id, string customerId, DataCollectorEndTransactionRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling EndTransaction");
            }
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling EndTransaction");
            }
            
            mEndTransactionPath = "/v2/transactions/{id}/end";
            if (!string.IsNullOrEmpty(mEndTransactionPath))
            {
                mEndTransactionPath = mEndTransactionPath.Replace("{format}", "json");
            }
            mEndTransactionPath = mEndTransactionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mEndTransactionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mEndTransactionStartTime, mEndTransactionPath, "Sending server request...");

            // make the HTTP request
            mEndTransactionCoroutine.ResponseReceived += EndTransactionCallback;
            mEndTransactionCoroutine.Start(mEndTransactionPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void EndTransactionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling EndTransaction: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling EndTransaction: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mEndTransactionStartTime, mEndTransactionPath, "Response received successfully.");
            if (EndTransactionComplete != null)
            {
                EndTransactionComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates and finalizes a collection of transaction information This operation basically encapsulates beginTransaction and endTransaction semantics into a single step and is used to update user balance information in Knetik.io
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Collection state information</param>
        public void UpdateCollection(string customerId, DataCollectorUpdateCollectionRequest request)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling UpdateCollection");
            }
            
            mUpdateCollectionPath = "/v2/collections";
            if (!string.IsNullOrEmpty(mUpdateCollectionPath))
            {
                mUpdateCollectionPath = mUpdateCollectionPath.Replace("{format}", "json");
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

            mUpdateCollectionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCollectionStartTime, mUpdateCollectionPath, "Sending server request...");

            // make the HTTP request
            mUpdateCollectionCoroutine.ResponseReceived += UpdateCollectionCallback;
            mUpdateCollectionCoroutine.Start(mUpdateCollectionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCollectionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCollection: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCollection: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateCollectionStartTime, mUpdateCollectionPath, "Response received successfully.");
            if (UpdateCollectionComplete != null)
            {
                UpdateCollectionComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the progress for the given transaction Use the event properties to update the state of the transaction
        /// </summary>
        /// <param name="id">Unique ID of the transaction being updated</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Transaction progress information</param>
        public void UpdateTransaction(string id, string customerId, DataCollectorUpdateTransactionRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateTransaction");
            }
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling UpdateTransaction");
            }
            
            mUpdateTransactionPath = "/v2/transactions/{id}";
            if (!string.IsNullOrEmpty(mUpdateTransactionPath))
            {
                mUpdateTransactionPath = mUpdateTransactionPath.Replace("{format}", "json");
            }
            mUpdateTransactionPath = mUpdateTransactionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mUpdateTransactionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateTransactionStartTime, mUpdateTransactionPath, "Sending server request...");

            // make the HTTP request
            mUpdateTransactionCoroutine.ResponseReceived += UpdateTransactionCallback;
            mUpdateTransactionCoroutine.Start(mUpdateTransactionPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateTransactionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateTransaction: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateTransaction: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateTransactionStartTime, mUpdateTransactionPath, "Response received successfully.");
            if (UpdateTransactionComplete != null)
            {
                UpdateTransactionComplete();
            }
        }

    }
}
