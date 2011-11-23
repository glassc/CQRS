using System;
using CQRS.Eventing;
using CQRS.Eventing.Storage;

namespace CQRS.Domain
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEventStore eventStore;

        public DomainRepository(IUnitOfWork unitOfWork, IEventStore eventStore)
        {
            this.unitOfWork = unitOfWork;
            this.eventStore = eventStore;
        }

        public T Create<T>(Guid id) where T : AggregateRoot
        {
            var result = (T)Activator.CreateInstance(typeof(T), id);
            unitOfWork.Track(result);
            return result;

        }

        public T Load<T>(Guid id) where T : AggregateRoot
        {
            var aggergateRoot = Create<T>(id);
            aggergateRoot.LoadFromHistory(eventStore.GetEventsFor(id)); 
            unitOfWork.Track(aggergateRoot);
            return aggergateRoot;
        }
    }
}