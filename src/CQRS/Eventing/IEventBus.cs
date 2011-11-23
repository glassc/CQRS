using System.Collections.Generic;

namespace CQRS.Eventing
{
    public interface IEventBus
    {
        void Publish(IEnumerable<Event> events);
    }
}