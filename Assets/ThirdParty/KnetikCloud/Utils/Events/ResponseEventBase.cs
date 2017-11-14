

namespace com.knetikcloud.Utils
{
    /// <inheritdoc />
    /// <summary>
    /// An event sent in response to a request that can potentially succeed or fail.
    /// </summary>
    public abstract class ResponseEventBase : IKnetikEvent
    {
        public object Requester { get; protected set; }

        /// <summary>
        /// Should the listener process this response (or not)?
        /// </summary>
        public bool ShouldProcess(object listener)
        {
            if ((Requester == null) || (listener == Requester))
            {
                return true;
            }

            return false;
        }

        public virtual void Reset()
        {
            Requester = null;
        }
    }
}
