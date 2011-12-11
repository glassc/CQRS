using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Eventing.Serialization;
using CQRS.Mongodb;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using UnitTests.Eventing;

namespace UnitTests.Mongodb
{
    [TestFixture]
    public class MongoDBEventStoreTest
    {
        private MongoDBEventStore eventStore;
        private TestEvent @event;
        private Mock<IMongoConnection> connection;
        private Mock<IObjectSerializer> objectSerializer;

        [SetUp]
        public void Setup()
        {
            connection = new Mock<IMongoConnection>();
            objectSerializer = new Mock<IObjectSerializer>();
            eventStore = new MongoDBEventStore(connection.Object, objectSerializer.Object);
            @event = new TestEvent {Sequence = 1};
        }

        [Test]
        public void ShouldSaveAnEvent()
        {

            objectSerializer.Setup(s => s.Serialize(@event)).Returns(string.Empty);
            eventStore.Save(new [] {@event});
            connection.Verify(c => c.Insert(It.IsAny<EventDocument>()));
            
        }

        [Test]
        public void ShouldGetEvents()
        {
            objectSerializer.Setup(s => s.Deserialize(string.Empty)).Returns(@event);
            connection.Setup(c => c.Find<EventDocument>(It.IsAny<IMongoQuery>())).Returns(new [] {new EventDocument{Sequence = 1, Event = string.Empty}});
            var result = eventStore.GetEventsFor(Guid.Empty);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(@event, result.ElementAt(0));
            

        }

    }
}
