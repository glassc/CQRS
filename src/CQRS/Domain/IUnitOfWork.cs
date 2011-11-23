namespace CQRS.Domain
{
    public interface IUnitOfWork
    {
        void Track(AggregateRoot aggregateRoot);
        void Commit();
        
    }
}
