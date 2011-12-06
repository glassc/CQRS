using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Mongodb;
using NUnit.Framework;
using UnitTests.Eventing;

namespace UnitTests.Mongodb
{
    [TestFixture]
    public class MongoDBEventStoreTest
    {
        private MongoDBEventStore eventStore;
        private TestEvent @event;

        [SetUp]
        public void Setup()
        {
         //   eventStore = new MongoDBEventStore();
            @event = new TestEvent();
        }

        [Test]
        public void ShouldSaveAnEvent()
        {
            eventStore.Save(new [] {@event});
        }
    }
}
