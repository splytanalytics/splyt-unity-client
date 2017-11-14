using System;
using com.knetikcloud.Client;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    /// <summary>
    /// Utility functions for ScriptableObjects.
    /// </summary>
    public static class KnetikEditorScriptableObjectUtis
    {
        /// <summary>
        /// Loads the save data from a Unity relative path. Returns null if the data doesn't exist.
        /// </summary>
        public static T LoadPersistentData<T>(string unityPathToFile) where T : ScriptableObject
        {
            // Ensure directory separators are correct
            unityPathToFile = unityPathToFile.Replace(KnetikAssetDatabaseUtils.OppositeDirectorySeparator, KnetikAssetDatabaseUtils.DirectorySeparator);

            // Path must contain Resources folder
            string resourcesFolder = string.Concat(
                                      KnetikAssetDatabaseUtils.DirectorySeparator,
                                      KnetikAssetDatabaseUtils.ResourcesFolderName,
                                      KnetikAssetDatabaseUtils.DirectorySeparator);

            if (!unityPathToFile.Contains(resourcesFolder))
            {
                Debug.LogWarningFormat("Failed to Load ScriptableObject of type, {0}, from path: {1}.", typeof(T), unityPathToFile);
                return null;
            }

            // Get Resource relative path - Resource path should only include folders underneath Resources and no file extension
            string resourceRelativePath = GetResourceRelativePath(unityPathToFile);

            // Remove file extension
            string fileExtension = System.IO.Path.GetExtension(unityPathToFile);
            resourceRelativePath = resourceRelativePath.Replace(fileExtension, string.Empty);

            return Resources.Load<T>(resourceRelativePath);
        }

        public static void SavePersistentData()
        {
            AssetDatabase.SaveAssets();
        }

        private static string GetResourceRelativePath(string unityPath)
        {
            string resourcesFolder = KnetikAssetDatabaseUtils.ResourcesFolderName + KnetikAssetDatabaseUtils.DirectorySeparator;
            string pathToResources = unityPath.Substring(0, unityPath.IndexOf(resourcesFolder, StringComparison.InvariantCulture));

            // Remove all folders leading up to the Resources folder
            pathToResources = unityPath.Replace(pathToResources, string.Empty);

            // Remove the Resources folder
            pathToResources = pathToResources.Replace(resourcesFolder, string.Empty);

            return pathToResources;
        }
    }
}
