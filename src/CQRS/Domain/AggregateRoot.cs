using System;
using System.Collections.Generic;
using CQRS.Eventing;


namespace CQRS.Domain
{
    public abstract class AggregateRoot
    {
        public readonly Guid Id;
        public event Action<Event> EventApplied;
        private readonly IDictionary<Type, Action<Event>> eventHandlers = new Dictionary<Type, Action<Event>>();

        protected AggregateRoot(Guid id)
        {
            this.Id = id;
        }


        protected void Apply(Event @event)
        {
            InvokeEventHandler(@event);
            if (EventApplied != null)
                EventApplied(@event);
        }

        protected void Register<T>(Action<T> eventHandler) where T : Event
        {
            var eventType = typeof (T);
            Guard.Against(HasEventHandlerFor(eventType), string.Format("There is already an event handler registered for event {0}", eventType.Name));
            eventHandlers.Add(eventType, e => eventHandler((T)e));
            
        }

        private bool HasEventHandlerFor(Type eventType)
        {
            return eventHandlers.ContainsKey(eventType);
        }

        private void InvokeEventHandler(Event @event)
        {
            
            Guard.Against(!HasEventHandlerFor(@event.GetType()), string.Format("No event handler could be found for event {0}", @event.GetType().Name));
            eventHandlers[@event.GetType()](@event);
        }

        public void LoadFromHistory(IEnumerable<Event> eventHistory)
        {
            foreach (var @event in eventHistory)
                InvokeEventHandler(@event);
 
        }

       
        

    
    }
}