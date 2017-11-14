using System;


namespace com.knetikcloud.Utils
{
    public static class KnetikLogger
    {
        public const string KnetikHeader = "Knetik";

        public static void Log(string msg)
        {
            msg = string.Format("{0}: '{1}'", KnetikHeader, msg);
            UnityEngine.Debug.Log(msg);
        }

        public static void Log(string url, string msg)
        {
            msg = string.Format("{0} - {1}: '{2}'", KnetikHeader, url, msg);
            UnityEngine.Debug.Log(msg);
        }

        public static void LogWarning(string msg)
        {
            msg = string.Format("{0}: '{1}'", KnetikHeader, msg);
            UnityEngine.Debug.LogWarning(msg);
        }

        public static void LogWarning(string url, string msg)
        {
            msg = string.Format("{0} - {1}: '{2}'", KnetikHeader, url, msg);
            UnityEngine.Debug.LogWarning(msg);
        }

        public static void LogError(string msg)
        {
            msg = string.Format("{0}: '{1}'", KnetikHeader, msg);
            UnityEngine.Debug.LogError(msg);
        }

        public static void LogError(string url, string msg)
        {
            msg = string.Format("{0} - {1}: '{2}'", KnetikHeader, url, msg);
            UnityEngine.Debug.LogError(msg);
        }

        public static void LogRequest(DateTime startTime, string url, string msg)
        {
            msg = string.Format("{0} [{1}] {2}: {3}", KnetikHeader, startTime.ToLongTimeString(), url, msg);
            UnityEngine.Debug.Log(msg);
        }

        public static void LogResponse(DateTime startTime, string url, string msg)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;

            msg = string.Format("{0} [{1}ms] {2}: {3}", KnetikHeader, (int)elapsedTime.TotalMilliseconds, url, msg);
            UnityEngine.Debug.Log(msg);
        }
    }
}
