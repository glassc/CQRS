using System;
using CQRS.Eventing;
using NUnit.Framework;
using UnitTests.Eventing;

namespace UnitTests.Domain
{
    [TestFixture]
    public class AggregateRootTest
    {
        private TestAggregateRoot aggergateRoot;
        private TestEvent @event;

        [SetUp]
        public void Setup()
        {
            aggergateRoot = new TestAggregateRoot(Guid.NewGuid());
            @event = new TestEvent();
        }

        [Test]
        public void ShouldCallEventHandler()
        {
            aggergateRoot.Test( @event );
            Assert.IsTrue(aggergateRoot.OnTestHasBeenCalled);
        }

        [Test]
        public void ShouldInvokeEventApplied_WhenEventIsApplied()
        {
            var testHandler = new EventApplied();
            aggergateRoot.EventApplied += testHandler.Apply;
            aggergateRoot.Test(@event);
            Assert.IsTrue(testHandler.HasBeenApplied);
        }

        [Test, ExpectedException(typeof(Exception))]
        public void ShouldThrowException_WhenNoEventHandlerIsFound()
        {
            aggergateRoot.TestWithNoHandler( new TestEventWithNoHandler() );
        }

        [Test]
        public void ShouldLoadFromHistory()
        {
            aggergateRoot.LoadFromHistory( new [] {@event});
            Assert.IsTrue(aggergateRoot.OnTestHasBeenCalled);
        }


        private class EventApplied
        {
            public bool HasBeenApplied {get;set;}

            public void Apply(Event @event)
            {
                HasBeenApplied = true;
            }
        
        }

        

        

    }
}
