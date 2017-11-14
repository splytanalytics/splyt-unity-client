using com.knetikcloud.Model;
using com.knetikcloud.Utils;

namespace com.knetikcloud.Events
{
    public class KnetikClientAuthenticatedEvent : IKnetikEvent
    {
        private static readonly KnetikClientAuthenticatedEvent sEvent = new KnetikClientAuthenticatedEvent();

        private KnetikClientAuthenticatedEvent()
        {   
        }

        public OAuth2Resource AuthToken { get; private set; }

        /// <summary>
        /// Get a static instance of the event to avoid dynamic memory allocations within Unity.
        /// NOTE: Unity is not multithreaded so we do not need to synchronize access.
        /// </summary>
        public static IKnetikEvent GetInstance(OAuth2Resource authToken)
        {
            sEvent.AuthToken = authToken;
            return sEvent;
        }

        public void Reset()
        {
            AuthToken = null;
        }
    }
}
