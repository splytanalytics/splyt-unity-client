using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public class KnetikEditorWizard : ScriptableWizard
    {
        #region Layout Constants
        private const int NavButtonLayoutInset = 5;
        private const int NavButtonLayoutHeight = 25;

        private const int UrlLayoutWidth = 140;
        private const int UrlLayoutHeight = 20;
        #endregion

        private enum WizardState
        {
            First = 0,

            Introduction = First,
            Setup,
            AppName,
            ClientId,
            ClientCredentials,
            UserCredentials,
            MonoBehaviour,

            Last = MonoBehaviour,
        }

        private readonly Dictionary<WizardState, string> mStateHelpTexts = new Dictionary<WizardState, string>();
        private WizardState mCurrentState;

        private GUIContent mHeaderText;
        private GUIContent mDisplayText;
        private GUIContent mPreviousButton;
        private GUIContent mNextButton;
        private GUIContent mCloseButton;
        private GUIContent mURLText;

        [MenuItem("Knetik Cloud/Wizard...")]
        private static void KnetikCloudDisplayWizard()
        {
            DisplayWizard<KnetikEditorWizard>("Knetik Wizard", "Create");
        }

        private void OnEnable()
        {
            IntializeStateTexts();

            mHeaderText = new GUIContent("Welcome to the Knetik C# SDK For Unity 5.x!\n ");
            mDisplayText = new GUIContent(mStateHelpTexts[mCurrentState]);

            mPreviousButton = new GUIContent("Previous...");
            mNextButton = new GUIContent("Next...");
            mCloseButton = new GUIContent("Close");
            mURLText = new GUIContent(KnetikEditorConstants.KnetikCloudWebsiteUrl);
            
            KnetikEditorSettingsWindow.OpenProjectSettingsWindow();
        }

        private void OnGUI()
        {
            DisplayText();
            DisplayNavButtons();
            DisplayUrl();
        }

        private void DisplayText()
        {
            // Account for buttons + URL text
            int combinedNavHeight = (NavButtonLayoutHeight + UrlLayoutHeight);

            Rect textDisplayRect = new Rect(0, 0, Screen.width, Screen.height - combinedNavHeight);

            bool wordWrap = GUI.skin.label.wordWrap;
            GUI.skin.label.wordWrap = true;

            GUILayout.BeginArea(textDisplayRect, GUI.skin.label);
            GUILayout.Label(mHeaderText);
            GUILayout.Label(mDisplayText);
            GUILayout.EndArea();

            GUI.skin.label.wordWrap = wordWrap;
        }

        private void DisplayNavButtons()
        {
            // Account for buttons + URL text
            int combinedNavHeight = (NavButtonLayoutHeight + UrlLayoutHeight);

            Rect navButtonRect = new Rect(NavButtonLayoutInset, Screen.height - combinedNavHeight, Screen.width - (NavButtonLayoutInset * 2), NavButtonLayoutHeight);
            GUILayout.BeginArea(navButtonRect);

            GUILayout.BeginHorizontal();
            if (mCurrentState != WizardState.First)
            {
                if (GUILayout.Button(mPreviousButton))
                {
                    mCurrentState--;
                    mDisplayText = new GUIContent(mStateHelpTexts[mCurrentState]);
                }
            }
            else
            {
                GUI.enabled = false;
                GUILayout.Button(mPreviousButton);
                GUI.enabled = true;
            }

            if (mCurrentState != WizardState.Last)
            {
                if (GUILayout.Button(mNextButton))
                {
                    mCurrentState++;
                    mDisplayText = new GUIContent(mStateHelpTexts[mCurrentState]);
                }
            }
            else
            {
                if (GUILayout.Button(mCloseButton))
                {
                    Close();
                }
            }
            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }

        private void DisplayUrl()
        {
            // Accounts for just the URL buttons
            Rect urlRect = new Rect((Screen.width / 2) - (UrlLayoutWidth / 2), Screen.height - UrlLayoutHeight, UrlLayoutWidth, UrlLayoutHeight);
            GUILayout.BeginArea(urlRect);

            Color originalColor = GUI.skin.label.normal.textColor;
            GUI.skin.label.normal.textColor = Color.blue;

            if (GUILayout.Button(mURLText, GUI.skin.label))
            {
                Application.OpenURL(KnetikEditorConstants.KnetikCloudWebsiteUrl);
            }

            GUI.skin.label.normal.textColor = originalColor;

            GUILayout.EndArea();
        }

        private void IntializeStateTexts()
        {
            mCurrentState = WizardState.Introduction;

            // NOTE: The line returns are to reserve space for the label word wraps to work correctly.

            mStateHelpTexts[WizardState.Introduction] =
                "This simple wizard will walk you through the initial setup process for the SDK. " +
                "If you have any questions please visit our website (link below).\n\n";

            mStateHelpTexts[WizardState.Setup] =
                "The first step is to ensure that you have registered an account with KnetikCloud. " +
                "Once you have an account you must setup an application on the KnetikCloud website.\n\n";

            mStateHelpTexts[WizardState.AppName] =
                "Once you have created an application enter the name in the 'App Name' project setting field.\n\n";

            mStateHelpTexts[WizardState.ClientId] =
                "The next step is to create a client ID and enter it in the 'Client ID' project setting field.\n\n";

            mStateHelpTexts[WizardState.ClientCredentials] =
                "Optional: If the application is setup to use a client secret then enter it in the 'Client Secret' project setting field.\n\n";

            mStateHelpTexts[WizardState.UserCredentials] =
                "Optional: If the application is setup to use user id/passwords then enter your own user id/password combination in the 'User Credentials' settings section.\n\n";

            mStateHelpTexts[WizardState.MonoBehaviour] =
                "Once you have configured the project you need to add the 'KnetikClient' behaviour to an object in your game scene. " +
                "Once it is initialized it will fire a 'KnetikClientReadyResponseEvent'. " +
                "You can then access it via the KnetikClient.DefaultClient static member to authenticate via the provided API.\n\n\n\n";
        }
    }
}
