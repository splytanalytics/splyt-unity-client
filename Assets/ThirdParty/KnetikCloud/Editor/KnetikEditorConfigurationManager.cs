using com.knetikcloud.Client;
using com.knetikcloud.Credentials;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorConfigurationManager
    {
        [SerializeField]
        private static KnetikProjectSettings sProjectSettings;

        [SerializeField]
        private static KnetikClientCredentials sClientCredentials;

        public static bool IsAppNameSet
        {
            get
            {
                return ((sProjectSettings != null) && !string.IsNullOrEmpty(sProjectSettings.AppName));
            }
        }

        public static string AppName
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.AppName : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.AppName = value;
                }
            }
        }

        public static string BaseStagingUrl
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.StagingUrl : null;
            }
        }

        public static string ClientId
        {
            get
            {
                return (sProjectSettings != null) ? sProjectSettings.ClientId : null;
            }
            set
            {
                if (sProjectSettings != null)
                {
                    sProjectSettings.ClientId = value;
                }
            }
        }

        public static string ClientSecret
        {
            get
            {
                return (sClientCredentials != null) ? sClientCredentials.ClientSecret : null;
            }
            set
            {
                if (sClientCredentials != null)
                {
                    sClientCredentials.ClientSecret = value;
                }
            }
        }

        public static void Initialize()
        {
            // NOTE: When the play button is pressed, all editor objects are unloaded so we need to reload things:  https://blogs.unity3d.com/2012/10/25/unity-serialization/
            if (sProjectSettings == null)
            {
                sProjectSettings = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikProjectSettings>(KnetikProjectSettings.SaveDataPath);
                if (sProjectSettings == null)
                {
                    sProjectSettings = ScriptableObject.CreateInstance<KnetikProjectSettings>();
                    KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(sProjectSettings, KnetikProjectSettings.SaveDataPath);
                }
            }

            if (sClientCredentials == null)
            {
                sClientCredentials = KnetikEditorScriptableObjectUtis.LoadPersistentData<KnetikClientCredentials>(KnetikClientCredentials.SaveDataPath);
                if (sClientCredentials == null)
                {
                    sClientCredentials = ScriptableObject.CreateInstance<KnetikClientCredentials>();
                    KnetikEditorAssetDatabaseUtils.CreateAssetAndDirectories(sClientCredentials, KnetikClientCredentials.SaveDataPath);
                }
            }
        }

        public static void SetDirty()
        {
            if (sProjectSettings != null)
            {
                EditorUtility.SetDirty(sProjectSettings);
            }

            if (sClientCredentials != null)
            {
                EditorUtility.SetDirty(sClientCredentials);
            }
        }
    }
}
