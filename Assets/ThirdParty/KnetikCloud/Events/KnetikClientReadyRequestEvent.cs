using com.knetikcloud.Utils;


namespace com.knetikcloud.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Event that is fired when the Knetik client has initialized and is ready to be used for authentication
    /// </summary>
    public class KnetikClientReadyRequestEvent : ResponseEventBase
    {
        private static readonly KnetikClientReadyRequestEvent sEvent = new KnetikClientReadyRequestEvent();

        private KnetikClientReadyRequestEvent()
        {
        }

        /// <summary>
        /// Get a static instance of the event to avoid dynamic memory allocations within Unity.
        /// NOTE: Unity is not multithreaded so we do not need to synchronize access.
        /// </summary>
        public static IKnetikEvent GetInstance(object requester)
        {
            sEvent.Requester = requester;
            return sEvent;
        }
    }
}
