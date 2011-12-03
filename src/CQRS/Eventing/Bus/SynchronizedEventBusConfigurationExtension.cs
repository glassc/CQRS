namespace CQRS.Eventing.Bus
{
    public static class SynchronizedEventBusConfigurationExtension
    {
        public static CQRS WithSynchronizedEventBus(this CQRS cqrs)
        {
            cqrs.AddCommand(new ConfigureSynchronizedEventBusCommand());
            return cqrs;
        }
    }
}