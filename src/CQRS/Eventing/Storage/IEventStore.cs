using System;
using System.Collections.Generic;

namespace CQRS.Eventing.Storage
{
    public interface IEventStore
    {
        
        void Save(IEnumerable<Event> events);
        IEnumerable<Event> GetEventsFor(Guid aggregateRootId);
    }
}