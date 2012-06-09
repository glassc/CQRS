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
                             CreateEvent( "CustomerUpdatedEvent", 1, new [] {new EventPropertiesViewModel("Address", "123 Fake Street")}),
                             CreateEvent( "ProjectCreatedEvent", 1, new [] {new EventPropertiesViewModel("Name", "Top Secret")}),
                             CreateEvent( "TaskedAddedEvent", 1, new [] {new EventPropertiesViewModel("Name", "UI Screen Shot")}),
                         };
        }

        private static EventViewModel CreateEvent(string type, int number, IEnumerable<EventPropertiesViewModel> properties)
        {
            return new EventViewModel(Guid.NewGuid(), type, number, DateTime.Now, properties);

        }
    }
}