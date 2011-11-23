using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Eventing;
using CQRS.Eventing.Storage;
using NUnit.Framework;

namespace UnitTests.Eventing.Storage
{
    [TestFixture]
    public class MemoryEventStoreTest
    {
        private MemoryEventStore eventStore;
        private IDictionary<Guid, ICollection<Event>> aggregateRootToEvent;
        private TestEvent @event;
        

        [SetUp]
        public void Setup()
        {
            aggregateRootToEvent = new Dictionary<Guid, ICollection<Event>>();
            eventStore = new MemoryEventStore(aggregateRootToEvent);
            @event = new TestEvent();
        }

        [Test]
        public void ShouldSaveEvents()
        {
            eventStore.Save(new [] {@event});
            Assert.IsTrue(aggregateRootToEvent.ContainsKey(@event.AggregateRootId));
            Assert.IsTrue(aggregateRootToEvent[@event.AggregateRootId].Contains(@event));
        }

        [Test]
        public void ShouldLoadAggregateRoot()
        {
            eventStore.Save(new[] { @event });
            var result = eventStore.GetEventsFor(@event.AggregateRootId);
            Assert.IsTrue(result.Contains(@event));
            Assert.AreEqual(1, result.Count());
        }

        [Test, ExpectedException(typeof(Exception))]
        public void ShouldHaveException_WhenAggregateRootNotSaved()
        {
            eventStore.GetEventsFor(Guid.NewGuid());
        }

    }
}
