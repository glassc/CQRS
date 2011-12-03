namespace CQRS.Eventing.Bus
{
    public class SynchronizedEventBus : IEventBus
    {
        

        public void Publish<T>(T @event) where T : Event
        {
            var closedType = typeof (IEventHandler<>).MakeGenericType(typeof (T));

            foreach (object handler in IoC.Container.ResolveAll(closedType))
            {
                var methodInfo = handler.GetType().GetMethod("Handle", new[] {typeof (T)});
                methodInfo.Invoke(handler, new object[] {@event});
            }
        }

        
    }
}