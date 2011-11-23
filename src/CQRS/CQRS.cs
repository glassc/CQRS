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
        private IEventStore eventStore;
        private IEventBus eventBus;
        // event bus, command bus, read model

        public static CQRS Configure()
        {
            return new CQRS();
        }


        public CQRS Container(IContainer container)
        {
            this.container = container;
            return this;
        }

        public CQRS EventStore(IEventStore eventStore)

        {
            this.eventStore = eventStore;
            return this;
        }

        public CQRS EventBus(IEventBus eventBus)
        {
            this.eventBus = eventBus;
            return this;
        }
       

        public void Start()
        {
            Guards();
            IoC.Set(container);
            container.Register(eventStore);
            container.Register(eventBus);
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IDomainRepository, DomainRepository>();
        }

        private void Guards()
        {
            Guard.Against(container == null, "You must assign a container"); 
            Guard.Against(eventStore == null, "You must assign an event store");
            Guard.Against(eventBus == null, "You must assign an event bus");
        }
    }
}
