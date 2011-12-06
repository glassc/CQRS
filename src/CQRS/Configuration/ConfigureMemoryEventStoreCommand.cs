using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Configuration;

namespace CQRS.Eventing.Storage
{
    public class ConfigureMemoryEventStoreCommand : IConfigureCommand
    {
        public void Run(IContainer container)
        {
            container.Register<IEventStore>(new MemoryEventStore());
        }
    }
}
