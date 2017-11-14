

using com.knetikcloud.Client;
using com.knetikcloud.Model;

namespace com.knetikcloud.Credentials
{
    public class KnetikTokenCredentials : IKnetikCredentials
    {
        private const string GrantTypeFacebook = "facebook";
        private const string GrantTypeGoogle = "google";

        private readonly string mTokenProvider;

        public enum ProviderType
        {
            Facebook,
            Google,
        }

        public string GrantType { get { return mTokenProvider; } }

        public bool IsConfigured { get { return !string.IsNullOrEmpty(Token); } }

        public string Token { get; private set; }

        public KnetikTokenCredentials(ProviderType type, string token)
        {
            switch (type)
            {
                case ProviderType.Facebook:
                    mTokenProvider = GrantTypeFacebook;
                    break;

                case ProviderType.Google:
                    mTokenProvider = GrantTypeGoogle;
                    break;

                default:
                    throw new KnetikException("Invalid value in 'ProviderType'!");
            }


            Token = token;
        }
    }
}
