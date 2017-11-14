using com.knetikcloud.Utils;


namespace com.knetikcloud.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Event that is fired when the Knetik client has initialized and is ready to be used for authentication
    /// </summary>
    public class KnetikClientReadyResponseEvent : ResponseEventBase
    {
        private static readonly KnetikClientReadyResponseEvent sEvent = new KnetikClientReadyResponseEvent();

        private KnetikClientReadyResponseEvent()
        {
        }

        public bool Ready { get; private set; }

        /// <summary>
        /// Get a static instance of the event to avoid dynamic memory allocations within Unity.
        /// NOTE: Unity is not multithreaded so we do not need to synchronize access.
        /// </summary>
        public static IKnetikEvent GetInstance(object requester, bool ready)
        {
            sEvent.Requester = requester;
            sEvent.Ready = ready;
            return sEvent;
        }

        public override void Reset()
        {
            Ready = false;
            base.Reset();
        }
    }
}
