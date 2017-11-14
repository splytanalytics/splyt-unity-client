using System.IO;
using com.knetikcloud.Utils;
using com.knetikcloud.Client;
using UnityEditor;
using UnityEngine;


namespace com.knetikcloud.UnityEditor
{
    public static class KnetikEditorAssetDatabaseUtils
    {
        /// <summary>
        /// Creates the asset and any directories that are missing along its path.
        /// </summary>
        public static void CreateAssetAndDirectories(Object unityObject, string unityFilePath)
        {
            string pathDirectory = Path.GetDirectoryName(unityFilePath);
            CreateDirectoriesInPath(pathDirectory);

            AssetDatabase.CreateAsset(unityObject, unityFilePath);
            AssetDatabase.SaveAssets();
        }

        #region Helpers
        private static bool DoesPathContainTrailingSlash(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                return false;
            }

            return (directoryPath[directoryPath.Length - 1] == KnetikAssetDatabaseUtils.DirectorySeparator);
        }

        private static void CreateDirectoriesInPath(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                KnetikLogger.LogError("Unity directory is empty!");
                return;
            }

            if (!DoesPathContainTrailingSlash(directoryPath))
            {
                directoryPath += KnetikAssetDatabaseUtils.DirectorySeparator;
            }

            // Ensure directory separators are correct
            directoryPath = directoryPath.Replace(KnetikAssetDatabaseUtils.OppositeDirectorySeparator, KnetikAssetDatabaseUtils.DirectorySeparator);

            string[] folders = directoryPath.Split(KnetikAssetDatabaseUtils.DirectorySeparator);

            // Error if path does NOT start from Assets
            if (folders[0] != KnetikAssetDatabaseUtils.AssetsFolderName)
            {
                string exceptionMessage = string.Format("Create Directories requires a full Unity path, including '{0}{1}'.", KnetikAssetDatabaseUtils.AssetsFolderName, KnetikAssetDatabaseUtils.DirectorySeparator);
                throw new KnetikException(0, exceptionMessage);
            }

            string pathToFolder = string.Empty;
            foreach (string folder in folders)
            {
                // Don't check for or create empty folders
                if (string.IsNullOrEmpty(folder))
                {
                    continue;
                }

                // Create folders that don't exist
                pathToFolder = string.Concat(pathToFolder, folder);

                if (!AssetDatabase.IsValidFolder(pathToFolder))
                {
                    string pathToParent = Directory.GetParent(pathToFolder).ToString();
                    AssetDatabase.CreateFolder(pathToParent, folder);
                    AssetDatabase.Refresh();
                }

                pathToFolder = string.Concat(pathToFolder, KnetikAssetDatabaseUtils.DirectorySeparator);
            }
        }
    }
    #endregion
}
