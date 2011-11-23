using System;
using CQRS.Eventing;

namespace UnitTests.Eventing
{
    public class TestEvent : Event
    {
        public TestEvent(Guid aggregateRootId) : base(aggregateRootId)
        {
        }

        public TestEvent() : this(Guid.NewGuid())
        {
            
        }

    }

    

    public class TestEventWithNoHandler : Event
    {
        public TestEventWithNoHandler(Guid aggregateRootId) : base(aggregateRootId)
        {
        }

        public TestEventWithNoHandler() : this(Guid.NewGuid())
        {
            
        }
    }
}