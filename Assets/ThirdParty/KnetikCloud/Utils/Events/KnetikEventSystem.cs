using System;
using System.Collections.Generic;


namespace com.knetikcloud.Utils
{
    /// <summary>
    /// An event system where listeners subscribe for a specific type of event and will be called back 
    /// in chronological order if any events of that type occur.
    /// 
    /// Note: This event system will be pumped via the update loop. As such events are not immediate and can have 1 frame of latency.
    /// </summary>
    public class KnetikEventSystem
    {
        #region Private Types
        private EventPublisherBase GetEventPublisherBase(Type type)
        {
            EventPublisherBase subscriber;
            if (mEventPublishers.TryGetValue(type, out subscriber))
            {
                return subscriber;
            }

            return null;
        }

        private EventSystemPublisher<T> GetEventPublisher<T>(Type type) where T : IKnetikEvent
        {
            EventPublisherBase subscriber = GetEventPublisherBase(type);
            if (subscriber != null)
            {
                EventSystemPublisher<T> eventPublisher = subscriber as EventSystemPublisher<T>;
                UnityEngine.Debug.Assert(eventPublisher != null, "Event publisher cannot be null!");
                return eventPublisher;
            }

            return null;
        }

        /// <summary>
        /// Base poster class so we can put generic posters in a container
        /// </summary>
        private abstract class EventPublisherBase
        {
            internal abstract bool IsEmpty
            {
                get;
            }

            internal abstract void PostEvent(IKnetikEvent e);
        }

        /// <summary>
        /// Per T poster that that allows us to store subscribers in a container and implement the IEventSystem interface
        /// NOTE: We have to jump through this poodle hoop because the compiler will NOT let us cast like the below (despite the constraint that T be an IKnetikEvent):
        /// EventSystemPoster<IKnetikEvent> eventSubscriber = (EventSystemPoster<IKnetikEvent>)subscriber;
        /// </summary>
        private class EventSystemPublisher<T> : EventPublisherBase where T : IKnetikEvent
        {
            public event EventHandler<T> Listeners
            {
                add
                {
                    mListeners += value;
                }

                remove
                {
                    mListeners -= value;
                }
            }

            internal override bool IsEmpty
            {
                get { return mListeners == null; }
            }

            internal override void PostEvent(IKnetikEvent e)
            {
                if (mListeners != null)
                {
                    mListeners((T)e);
                }
            }

            private event EventHandler<T> mListeners;
        }
        #endregion

        private readonly Dictionary<Type, EventPublisherBase> mEventPublishers = new Dictionary<Type, EventPublisherBase>();


        public void Publish(IKnetikEvent e)
        {
            UnityEngine.Debug.Assert(e != null, "Event System - parameter 'e' cannot be null!");

            EventPublisherBase subscriber = GetEventPublisherBase(e.GetType());
            if (subscriber != null)
            {
                try
                {
                    subscriber.PostEvent(e);
                }
                catch (Exception ex)
                {
                    KnetikLogger.LogError(string.Format("There was an error processing an event! Event: {0} : {1}, Reason: {2}.", e.GetType(), e, ex));
                }
            }
        }

        public void Subscribe<T>(EventHandler<T> subscriber) where T : IKnetikEvent
        {
            UnityEngine.Debug.Assert(subscriber != null, "Event subscriber parameter cannot be null!");

            EventSystemPublisher<T> eventPublisher = GetEventPublisher<T>(typeof(T));
            if (eventPublisher == null)
            {
                eventPublisher = new EventSystemPublisher<T>();
                mEventPublishers.Add(typeof(T), eventPublisher);
            }

            eventPublisher.Listeners += subscriber;
        }

        public void Unsubscribe<T>(EventHandler<T> subscriber) where T : IKnetikEvent
        {
            UnityEngine.Debug.Assert(subscriber != null, "Event subscriber cannot be null!");

            EventSystemPublisher<T> eventPublisher = GetEventPublisher<T>(typeof(T));
            if (eventPublisher != null)
            {
                eventPublisher.Listeners -= subscriber;

                if (eventPublisher.IsEmpty)
                {
                    mEventPublishers.Remove(typeof(T));
                }
            }
        }
    }
}
