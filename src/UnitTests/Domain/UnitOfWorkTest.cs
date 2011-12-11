using System;
using System.Collections.Generic;
using CQRS.Domain;
using CQRS.Eventing;
using CQRS.Eventing.Bus;
using CQRS.Eventing.Storage;
using Moq;
using NUnit.Framework;
using UnitTests.Eventing;

namespace UnitTests.Domain
{
    public class UnitOfWorkTest
    {
        private UnitOfWork unitOfWork;
        private Queue<Event> eventQueue;
        private TestAggregateRoot aggregateRoot;
        private Mock<IEventStore> eventStore;
        private Mock<IEventBus> eventBus;
         
            
        [SetUp]
        public void Setup()
        {
            eventStore = new Mock<IEventStore>();
            eventBus = new Mock<IEventBus>();
            eventQueue = new Queue<Event>();
            unitOfWork = new UnitOfWork(eventQueue, eventStore.Object, eventBus.Object);
            aggregateRoot = new TestAggregateRoot(Guid.Empty);
        }

    

        [Test]
        public void ShouldTrackChangedEvent_WhenEventHasBeenApplied()
        {
            unitOfWork.Track(aggregateRoot);
            var @event = new TestEvent();
            aggregateRoot.Test(  @event );
            Assert.AreEqual(1, eventQueue.Count);
            Assert.AreEqual(@event, eventQueue.Dequeue());
        }

        [Test]
        public void ShouldCommitChanges()
        {
            unitOfWork.Track(aggregateRoot);
            var @event = new TestEvent();
            aggregateRoot.Test(@event);
            unitOfWork.Commit();
            eventStore.Verify(s => s.Save(eventQueue));
            eventBus.Verify(b => b.Publish<Event>(@event));
            Assert.AreEqual(0, eventQueue.Count);

        }

      
    }
}