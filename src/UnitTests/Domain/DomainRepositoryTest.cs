using System;
using CQRS.Domain;
using CQRS.Eventing;
using CQRS.Eventing.Storage;
using Moq;
using NUnit.Framework;
using UnitTests.Eventing;

namespace UnitTests.Domain
{
    [TestFixture]
    public class DomainRepositoryTest
    {
        private DomainRepository repository;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IEventStore> eventStore;
        private readonly Guid Id = Guid.NewGuid();
        private TestEvent @event;

        [SetUp]
        public void Setup()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            eventStore = new Mock<IEventStore>();
            repository = new DomainRepository(unitOfWork.Object, eventStore.Object);
            @event = new TestEvent();
        }

        [Test]
        public void ShouldCreateNewAggergateRoot()
        {
            var result = repository.Create<TestAggregateRoot>(Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(Id, result.Id);
            unitOfWork.Verify(m => m.Track(result));
        }

        [Test]
        public void ShouldLoadAggergateRoot()
        {

            eventStore.Setup(e => e.GetEventsFor(Id)).Returns(new[] {@event});
            var result = repository.Load<TestAggregateRoot>(Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(Id, result.Id);
            Assert.IsTrue(result.OnTestHasBeenCalled);
            unitOfWork.Verify(w => w.Track(result));
        }

        
    }
}
