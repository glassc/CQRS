using System.Collections.Generic;

namespace CQRS.Eventing
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}