using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Eventing.Storage
{
    public class MemoryEventStore : IEventStore
    {
      
        private readonly IDictionary<Guid, ICollection<Event>> storage;

        public MemoryEventStore()
            : this(new Dictionary<Guid, ICollection<Event>>())
        {
            
        }

        public MemoryEventStore(IDictionary<Guid, ICollection<Event>> storage)
        {
            this.storage = storage;
        }

        public void Save(IEnumerable<Event> events)
        {

            foreach (var @event in events)
            {
                var aggregateRootId = @event.AggregateRootId;
                if (!storage.ContainsKey(aggregateRootId)) storage.Add(aggregateRootId, new List<Event>());
                storage[aggregateRootId].Add(@event);
            }

            
        }

        public IEnumerable<Event> GetEventsFor(Guid aggregateRootId)
        {
            Guard.Against(!storage.ContainsKey(aggregateRootId), string.Format("Aggregate Root {0} has not been stored", aggregateRootId));
            return storage[aggregateRootId];
        }
    }
}
