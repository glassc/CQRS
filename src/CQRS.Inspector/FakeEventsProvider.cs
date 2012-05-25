using System;
using System.Collections.Generic;

namespace CQRS.Inspector
{
    public class FakeEventsProvider : IEventsProvider
    {
        public IEnumerable<EventViewModel> Get()
        {
            return new List<EventViewModel>
                         {
                             CreateEvent( "CustomerCreatedEvent", 1, new [] {new EventPropertiesViewModel("Name", "Chris"), new EventPropertiesViewModel("Age", "29")  }),
                             CreateEvent( "CustomerUpdatedEvent", 1, new EventPropertiesViewModel[0]),
                         };
        }

        private EventViewModel CreateEvent(string type, int number, EventPropertiesViewModel[] properties)
        {
            return new EventViewModel(Guid.NewGuid(), type, number, DateTime.Now, properties);

        }
    }
}