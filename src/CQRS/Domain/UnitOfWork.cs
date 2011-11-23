using System.Collections.Generic;
using CQRS.Eventing;
using CQRS.Eventing.Storage;

namespace CQRS.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IEventBus eventBus;
        private readonly Queue<Event> eventQueue;
        private readonly IEventStore eventStore;

        public UnitOfWork(Queue<Event> eventQueue, IEventStore eventStore)
        {
            this.eventQueue = eventQueue;
          
            this.eventStore = eventStore;
        }

        public UnitOfWork(IEventStore eventStore) : this(new Queue<Event>(), eventStore)
        {
            this.eventStore = eventStore;
          
        }

        public void Track(AggregateRoot aggregateRoot)
        {
            aggregateRoot.EventApplied += (e) => eventQueue.Enqueue(e);
        }

        public void Commit()
        {
            eventStore.Save(eventQueue);
          
            eventQueue.Clear();
        }

    }
}