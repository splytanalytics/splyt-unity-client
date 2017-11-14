

namespace com.knetikcloud.Utils
{
    /// <inheritdoc />
    /// <summary>
    /// Send a request to listeners via the event system.
    /// Once the request is processed a response will be issued via the event system.
    /// </summary>
    public abstract class RequestEventBase : IKnetikEvent
    {
        public object Requester { get; protected set; }

        public abstract void Reset();
    }
}
