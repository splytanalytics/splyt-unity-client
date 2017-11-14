
namespace com.knetikcloud.Utils
{
    /// <summary>
    /// An event that client code can subscribe to.
    /// </summary>
    public interface IKnetikEvent
    {
        /// <summary>
        /// Reset the event back to its default state
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// Event-listening callback for specific type of event.
    /// </summary>
    public delegate void EventHandler<TEvent>(TEvent e) where TEvent : IKnetikEvent;
}
