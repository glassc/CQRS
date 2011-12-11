using System;
using System.Linq;
using CQRS.Mongodb;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NUnit.Framework;

namespace UnitTests.Mongodb
{
    [TestFixture]
    public class MongoConnectionTest
    {
        private const string Database = "test_eventstore";
        private const string CollectionName = "EventDocument";
        private readonly string ConnectionString = string.Format("mongodb://localhost/{0}?safe=true", Database);

        private MongoConnection connection;

        private MongoServer server;
        

        [SetUp]
        public void Setup()
        {
            connection = new MongoConnection(ConnectionString);
    
            server = MongoServer.Create(ConnectionString);
            
        }

        [TearDown]
        public void TearDown()
        {
            server.DropDatabase(Database);     
        }

       

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            MapEventClassToDocument.Map();
        }

        [Test]
        public void ShouldInsertDocument()
        {
            
            var document = new EventDocument {EventId = Guid.NewGuid().ToString(), Event = "event", Sequence = 1, AggregateRootId = Guid.NewGuid().ToString()};
            connection.Insert(document);
            var collection = GetCollection<EventDocument>(CollectionName).FindAll();
            Assert.AreEqual(1, collection.Count());
            AssertDocumentsAreEqual(document, collection.First());
          
          
        }

        [Test]
        public void ShouldFindDocument()
        {
         
            var expected = new EventDocument { EventId = Guid.NewGuid().ToString(), Event = "event", Sequence = 1, AggregateRootId = Guid.NewGuid().ToString()};
            GetCollection<EventDocument>(CollectionName).Insert(expected);
            
            var actual = connection.Find<EventDocument>(Query.EQ("EventId", expected.EventId));
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count());
            AssertDocumentsAreEqual(expected, actual.First());
              
        }

        private static void AssertDocumentsAreEqual(EventDocument expected, EventDocument actual)
        {
            Assert.AreEqual(expected.EventId, actual.EventId);
            Assert.AreEqual(expected.Event, actual.Event);
            Assert.AreEqual(expected.Sequence, actual.Sequence);
            Assert.AreEqual(expected.AggregateRootId, actual.AggregateRootId);

        }

        private MongoCollection<T> GetCollection<T>(string name)
        {
            var db = server.GetDatabase(Database);
            return db.GetCollection<T>(name);
        }

        
    }
}