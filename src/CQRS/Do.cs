using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CQRS.Configuration;
using CQRS.Configuration.NInject;
using CQRS.Domain;
using CQRS.Eventing;
using CQRS.Eventing.Bus;
using CQRS.Eventing.Storage;

namespace CQRS
{
    

    public class CQRS
    {
        private IContainer container;
        private readonly ICollection<IConfigureCommand> configurePipeline;
        
        public static CQRS Configure()
        {
            return new CQRS();
        }

        public CQRS()
        {
            configurePipeline = new List<IConfigureCommand>();
        }


        public CQRS Container(IContainer container)
        {
            this.container = container;
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
