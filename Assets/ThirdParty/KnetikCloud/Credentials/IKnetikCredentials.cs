

namespace com.knetikcloud.Credentials
{
    /// <summary>
    /// Base credentials class that are used to authenticate with the Knetik Servers
    /// </summary>
    public interface IKnetikCredentials
    {
        string GrantType { get; }

        bool IsConfigured { get; }
    }
}
