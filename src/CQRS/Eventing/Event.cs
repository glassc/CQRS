using System;

namespace CQRS.Eventing
{
    public abstract class Event
    {
        public readonly Guid EventId;
        public readonly DateTime CreatedTimeStamp;
        public int Sequence { get;  set; }
        public Guid AggregateRootId { get; private set; }

        protected Event(Guid aggregateRootId)
        {
            EventId = Guid.NewGuid();
            CreatedTimeStamp = DateTime.Now;
            AggregateRootId = aggregateRootId;
        }
        
       

        
    }
}