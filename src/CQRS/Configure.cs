using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Configuration;
using CQRS.Domain;
using CQRS.Eventing.Storage;

namespace CQRS
{
    public class Configure
    {
        private IContainer container;

        public static Configure With()
        {
            return new Configure();
        }

        public Configure Using(IContainer container)
        {
            this.container = container;
            return this;
        }

        public void Start()
        {
            IoC.Container = container;
            container.Register<IEventStore, MemoryEventStore>();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IDomainRepository, DomainRepository>();
        }
    }
}
