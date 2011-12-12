using System.Collections.Generic;
using CQRS.Configuration;
using CQRS.Eventing.Bus;
using CQRS.Eventing.Storage;

namespace CQRS
{
    

    public class Configure
    {
        private IContainer container;
        private readonly ICollection<IConfigureCommand> configurePipeline;
        
        public static Configure CQRS()
        {
            return new Configure();
        }

        public Configure()
        {
            configurePipeline = new List<IConfigureCommand>();
        }


        public Configure Container(IContainer container)
        {
            this.container = container;
            return this;
        }

        public Configure UsingSynchronizedEventBus()
        {
            AddCommand(new ConfigureSynchronizedEventBusCommand());
            return this;
        }

        public Configure UsingMemoryEventStore()
        {
            AddCommand(new ConfigureMemoryEventStoreCommand());
            return this;
        }

        public void Start()
        {
            Guards();
            IoC.Set(container);
            AddCommand(new RequiredComponentsConfigurationCommand());
            RunPipeLine();  
        }

        private void RunPipeLine()
        {
            foreach (var configure in configurePipeline)
                configure.Run(container);
           
        }

        private void Guards()
        {
            Guard.Against(container == null, "You must assign a container");
          
        }

        public void AddCommand(IConfigureCommand command)
        {
            configurePipeline.Add(command);
        
        }

        
    }

}
