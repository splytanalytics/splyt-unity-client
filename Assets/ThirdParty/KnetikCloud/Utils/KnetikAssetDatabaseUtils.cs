

namespace com.knetikcloud.Client
{
    public static class KnetikAssetDatabaseUtils
    {
#if UNITY_STANDALONE_WIN
        public const char DirectorySeparator = '\\';
        public const char OppositeDirectorySeparator = '/';
#else
        public const char DirectorySeparator = '/';
        public const char OppositeDirectorySeparator = '\\';
#endif
        public const string AssetsFolderName = "Assets";
        public const string ResourcesFolderName = "Resources";
    }
}
