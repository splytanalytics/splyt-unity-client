using com.knetikcloud.Credentials;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorSettingsWindow : EditorWindow
    {
        #region Layout Constants
        private const int ControlButtonLayoutInset = 5;
        private const int ControlButtonLayoutHeight = 45;
        #endregion

        private KnetikUserCredentials mUserCredentials;

        private GUIContent mProjectSettingsHeaderLabel;
        private GUIContent mAppName;
        private GUIContent mClientId;

        private GUIContent mClientCredentialsHeaderLabel;
        private GUIContent mClientSecret;

        private GUIContent mUserCredentialsHeaderLabel;
        private GUIContent mUserCredentialsId;
        private GUIContent mUserCredentialsPassword;

        private GUIContent mSaveButton;

        [MenuItem("Knetik Cloud/Project Settings...")]
        private static void KnetikCloudProjectSettings()
        {
            OpenProjectSettingsWindow();
        }

        public static void OpenProjectSettingsWindow()
        {
            GetWindow<KnetikEditorSettingsWindow>("Knetik Settings");
        }

        private void OnEnable()
        {
            // Ensure the settings are loaded (if available)
            KnetikEditorConfigurationManager.Initialize();
            mUserCredentials = KnetikUserCredentials.Load();

            mProjectSettingsHeaderLabel = new GUIContent("Project Configuration", "Project wide settings that should be checked into source control (if used).");
            mAppName = new GUIContent("App Name", "The App Name for your project as configured in the KnetikCloud Web interface.  E.g. 'my-first-game' (without quotes).");
            mClientId = new GUIContent("Client ID", "The client ID as configured in the KnetikCloud Web interface.");

            mClientCredentialsHeaderLabel = new GUIContent("Client Credentials", "Optional: Settings that apply if the grant type is 'client_credentials'.\nShould be checked into source control (if used).");
            mClientSecret = new GUIContent("Client Secret", "Optional: Must match the secret configured in the KnetikCloud Web interface.");

            mUserCredentialsHeaderLabel = new GUIContent("User Credentials", "Optional: Per developer settings that apply if the grant type is 'password'.");
            mUserCredentialsId = new GUIContent("User Id", "Optional: Per developer user account to use.");
            mUserCredentialsPassword = new GUIContent("Password", "Optional: Per developer account password to use.");

            mSaveButton = new GUIContent("Save");
        }

        private void OnGUI()
        {
            Rect displayRect = new Rect(0, 0, Screen.width, Screen.height - ControlButtonLayoutHeight);
            GUILayout.BeginArea(displayRect);

            DisplayProjectSettingsGUI();
            DisplayClientCredentialsGUI();
            DisplayUserCredentialsGUI();

            GUILayout.EndArea();

            if (GUI.changed)
            {
                KnetikEditorConfigurationManager.SetDirty();
            }

            DisplayControlButtons();

            Repaint();
        }

        private void DisplayProjectSettingsGUI()
        {
            EditorGUILayout.LabelField(mProjectSettingsHeaderLabel, EditorStyles.boldLabel);

            KnetikEditorConfigurationManager.AppName = EditorGUILayout.TextField(mAppName, KnetikEditorConfigurationManager.AppName);
            KnetikEditorConfigurationManager.ClientId = EditorGUILayout.TextField(mClientId, KnetikEditorConfigurationManager.ClientId);
            EditorGUILayout.Space();
        }

        private void DisplayClientCredentialsGUI()
        {
            EditorGUILayout.LabelField(mClientCredentialsHeaderLabel, EditorStyles.boldLabel);
            KnetikEditorConfigurationManager.ClientSecret = EditorGUILayout.TextField(mClientSecret, KnetikEditorConfigurationManager.ClientSecret);
            EditorGUILayout.Space();
        }

        private void DisplayUserCredentialsGUI()
        {
            EditorGUILayout.LabelField(mUserCredentialsHeaderLabel, EditorStyles.boldLabel);
            mUserCredentials.UserId = EditorGUILayout.TextField(mUserCredentialsId, mUserCredentials.UserId);
            mUserCredentials.Password = EditorGUILayout.PasswordField(mUserCredentialsPassword, mUserCredentials.Password);
            EditorGUILayout.Space();
        }

        private void DisplayControlButtons()
        {
            Rect controlButtonRect = new Rect(ControlButtonLayoutInset, Screen.height - ControlButtonLayoutHeight, Screen.width - (ControlButtonLayoutInset * 2), ControlButtonLayoutHeight);
            GUILayout.BeginArea(controlButtonRect);

            if (GUILayout.Button(mSaveButton))
            {
                SaveSettings();
            }

            GUILayout.EndArea();
        }

        private void SaveSettings()
        {
            KnetikEditorScriptableObjectUtis.SavePersistentData();
            KnetikUserCredentials.Save(mUserCredentials);
        }
    }
}
