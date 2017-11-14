using System.Collections.Generic;
using com.knetikcloud.Api;
using com.knetikcloud.Client;
using com.knetikcloud.Credentials;
using com.knetikcloud.Events;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
using UnityEngine;


namespace KnetikTests
{
    public class KnetiApiTests : MonoBehaviour
    {
        #region Mono Behaviours
        private void Awake()
        {
            KnetikGlobalEventSystem.Subscribe<KnetikClientReadyResponseEvent>(OnClientReady);
            KnetikGlobalEventSystem.Subscribe<KnetikClientAuthenticatedEvent>(OnClientAuthenticated);
        }

        private void Start()
        {
            // Due to order of initialization the client may send a notification of being ready before we setup our
            // listener for that event.  As such, we verify the status when the this object is initialized.
            KnetikGlobalEventSystem.Publish(KnetikClientReadyRequestEvent.GetInstance(this));
        }

        private void OnDestroy()
        {
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientReadyResponseEvent>(OnClientReady);
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientAuthenticatedEvent>(OnClientAuthenticated);
        }

        #endregion

        private void OnClientReady(KnetikClientReadyResponseEvent e)
        {
            if (e.ShouldProcess(this))
            {
                KnetikClient.DefaultClient.AuthenticateWithUserCredentials(KnetikClient.ServerEnvironment.Staging, KnetikUserCredentials.Load());
            }
        }

        private static void OnClientAuthenticated(KnetikClientAuthenticatedEvent e)
        {
            KnetikLogger.Log("*** CLIENT AUTHENTICATED SUCCESSFULLY ***");
            GetUserId();
        }

        private static void GetUserId()
        {
            UsersApi userApi = new UsersApi();
            userApi.GetUserComplete += GetUserComplete;

            userApi.GetUser("me");
        }

        private static void GetUserComplete(UserResource response)
        {
            KnetikLogger.Log("*** USER RETRIEVED SUCCESSFULLY ***");
            KnetikLogger.Log(response.ToString());

            KnetikLogger.Log("=== POLYMORPHIC TEST CONFIRMATION ===");

            foreach (string key in response.AdditionalProperties.Keys)
            {
                KnetikLogger.Log(string.Format("{0}\n{1}", key, response.AdditionalProperties[key]));
            }
        }
    }
}
