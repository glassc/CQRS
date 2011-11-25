using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Configuration;
using CQRS.Configuration.NInject;
using CQRS.Domain;
using CQRS.Eventing;
using CQRS.Eventing.Storage;

namespace CQRS
{
    public class CQRS
    {
        private IContainer container;
        
        public static CQRS Configure()
        {
            return new CQRS();
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
            container.Register<IEventBus, SynchronizedEventBus>();
            container.Register<IEventStore>( new MemoryEventStore());
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IDomainRepository, DomainRepository>();
        }

        private void Guards()
        {
            Guard.Against(container == null, "You must assign a container"); 
        }
    }
}
