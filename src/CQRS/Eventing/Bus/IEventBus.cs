namespace CQRS.Eventing.Bus
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}