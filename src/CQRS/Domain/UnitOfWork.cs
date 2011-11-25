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

        public UnitOfWork(Queue<Event> eventQueue, IEventStore eventStore, IEventBus eventBus)
        {
            this.eventQueue = eventQueue;
            this.eventBus = eventBus;

            this.eventStore = eventStore;
        }

        public UnitOfWork(IEventStore eventStore, IEventBus eventBus) : this(new Queue<Event>(), eventStore, eventBus)
        {
            this.eventStore = eventStore;
            this.eventBus = eventBus;
        }

        public void Track(AggregateRoot aggregateRoot)
        {
            aggregateRoot.EventApplied += (e) => eventQueue.Enqueue(e);
        }

        public void Commit()
        {
            eventStore.Save(eventQueue);
            foreach (var @event in eventQueue)
                eventBus.Publish(@event);
            eventQueue.Clear();
        }

    }
}