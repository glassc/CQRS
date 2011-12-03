namespace CQRS.Eventing.Storage
{
    public static class MemoryEventStoreConfigurationExtension
    {
        public static CQRS WithMemoryEventStore(this CQRS cqrs)
        {
            cqrs.AddCommand(new ConfigureMemoryEventStoreCommand());
            return cqrs;
        }
    }
}