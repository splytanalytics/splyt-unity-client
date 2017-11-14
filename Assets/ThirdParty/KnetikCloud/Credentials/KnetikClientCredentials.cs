using System;
using UnityEngine;


namespace com.knetikcloud.Credentials
{
    [Serializable]
    public class KnetikClientCredentials : ScriptableObject, IKnetikCredentials
    {
        public const string SaveDataPath = "Assets\\Resources\\KnetikCloud\\KnetikClientCredentials.asset";
        public const string ResourceName = "KnetikCloud\\KnetikClientCredentials";

        public string GrantType { get { return "client_credentials"; } }

        public bool IsConfigured { get { return !string.IsNullOrEmpty(ClientSecret); } }

        public string ClientSecret;

        public static KnetikClientCredentials Load()
        {
            return Resources.Load<KnetikClientCredentials>(ResourceName);
        }
    }
}
