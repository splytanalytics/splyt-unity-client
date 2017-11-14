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
    public interface IUsersApi
    {
        
        /// <summary>
        /// Submit a new user event Declares to the Knetik.io platform that the user is new at the given point in time. If the &#39;checked&#39; parameter is provided and set to &#39;true&#39;, however, the current state of the user in the Knetik.io platform is examined to determine if the user was previously declared as new and, if so, the user information is not updated in the Knetik.io platform.
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">New user information</param>
        /// <param name="_checked">Flag indicating whether the user state should be checked before updating the state in the Knetik.io platform</param>
        void NewUser(string customerId, DataCollectorNewUserRequest request, bool? _checked);

        /// <summary>
        /// Updates the entity state for the given user 
        /// </summary>
        /// <param name="id">ID of the user for whom state is being updated</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Updated user state information</param>
        void UpdateUserState(string id, string customerId, DataCollectorUpdateUserStateRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersApi : IUsersApi
    {
        private readonly KnetikCoroutine mNewUserCoroutine;
        private DateTime mNewUserStartTime;
        private string mNewUserPath;
        private readonly KnetikCoroutine mUpdateUserStateCoroutine;
        private DateTime mUpdateUserStateStartTime;
        private string mUpdateUserStatePath;

        public delegate void NewUserCompleteDelegate();
        public NewUserCompleteDelegate NewUserComplete;

        public delegate void UpdateUserStateCompleteDelegate();
        public UpdateUserStateCompleteDelegate UpdateUserStateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersApi()
        {
            mNewUserCoroutine = new KnetikCoroutine();
            mUpdateUserStateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Submit a new user event Declares to the Knetik.io platform that the user is new at the given point in time. If the &#39;checked&#39; parameter is provided and set to &#39;true&#39;, however, the current state of the user in the Knetik.io platform is examined to determine if the user was previously declared as new and, if so, the user information is not updated in the Knetik.io platform.
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="request">New user information</param>
        /// <param name="_checked">Flag indicating whether the user state should be checked before updating the state in the Knetik.io platform</param>
        public void NewUser(string customerId, DataCollectorNewUserRequest request, bool? _checked)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling NewUser");
            }
            
            mNewUserPath = "/v2/users";
            if (!string.IsNullOrEmpty(mNewUserPath))
            {
                mNewUserPath = mNewUserPath.Replace("{format}", "json");
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

            mNewUserStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mNewUserStartTime, mNewUserPath, "Sending server request...");

            // make the HTTP request
            mNewUserCoroutine.ResponseReceived += NewUserCallback;
            mNewUserCoroutine.Start(mNewUserPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void NewUserCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling NewUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling NewUser: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mNewUserStartTime, mNewUserPath, "Response received successfully.");
            if (NewUserComplete != null)
            {
                NewUserComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates the entity state for the given user 
        /// </summary>
        /// <param name="id">ID of the user for whom state is being updated</param>
        /// <param name="customerId">customerId</param>
        /// <param name="request">Updated user state information</param>
        public void UpdateUserState(string id, string customerId, DataCollectorUpdateUserStateRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUserState");
            }
            // verify the required parameter 'customerId' is set
            if (customerId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'customerId' when calling UpdateUserState");
            }
            
            mUpdateUserStatePath = "/v2/users/{id}";
            if (!string.IsNullOrEmpty(mUpdateUserStatePath))
            {
                mUpdateUserStatePath = mUpdateUserStatePath.Replace("{format}", "json");
            }
            mUpdateUserStatePath = mUpdateUserStatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mUpdateUserStateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserStateStartTime, mUpdateUserStatePath, "Sending server request...");

            // make the HTTP request
            mUpdateUserStateCoroutine.ResponseReceived += UpdateUserStateCallback;
            mUpdateUserStateCoroutine.Start(mUpdateUserStatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserStateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserState: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserState: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateUserStateStartTime, mUpdateUserStatePath, "Response received successfully.");
            if (UpdateUserStateComplete != null)
            {
                UpdateUserStateComplete();
            }
        }

    }
}
