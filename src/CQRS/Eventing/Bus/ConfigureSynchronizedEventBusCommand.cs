using CQRS.Configuration;

namespace CQRS.Eventing.Bus
{

    public class ConfigureSynchronizedEventBusCommand : IConfigureCommand
    {
        public void Run(IContainer container)
        {
            container.Register<IEventBus, SynchronizedEventBus>();
        }
    }
}