using System;

namespace CQRS.Domain
{
    public interface IDomainRepository
    {
        T Create<T>(Guid id) where T : AggregateRoot;
        T Load<T>(Guid id) where T : AggregateRoot;
        
    }
}
