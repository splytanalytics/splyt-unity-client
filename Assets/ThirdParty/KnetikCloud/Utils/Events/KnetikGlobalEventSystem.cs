

namespace com.knetikcloud.Utils
{
    /// <summary>
    /// Global event system
    /// </summary>
    public static class KnetikGlobalEventSystem
    {
        private static readonly KnetikEventSystem sEventSystem = new KnetikEventSystem();

        public static void Publish(IKnetikEvent e)
        {
            sEventSystem.Publish(e);
        }

        public static void Subscribe<T>(EventHandler<T> handler) where T : IKnetikEvent
        {
            sEventSystem.Subscribe(handler);
        }

        public static void Unsubscribe<T>(EventHandler<T> handler) where T : IKnetikEvent
        {
            sEventSystem.Unsubscribe(handler);
        }
    }
}
