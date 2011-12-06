using System;
using System.Collections.Generic;
using System.Linq;
using CQRS.Eventing;
using CQRS.Eventing.Serialization;
using CQRS.Eventing.Storage;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace CQRS.Mongodb
{
    public class MongoDBEventStore : IEventStore
    {
        private readonly IMongoConnection connection;
        private readonly IObjectSerializer serializer;

        public MongoDBEventStore(IMongoConnection connection, IObjectSerializer serializer)
        {
            this.connection = connection;
            this.serializer = serializer;
        }


        public void Save(IEnumerable<Event> events)
        {
            foreach (var @event in events)
                connection.Insert(CreateDocumentFrom(@event));
           
        }


        private static EventDocument CreateDocumentFrom(Event @event)
        {
            return new EventDocument
                       {
                           AggregateRootId = @event.AggregateRootId.ToString(),
                           Event = string.Empty,
                           EventId = @event.EventId.ToString(),
                           Sequence = @event.Sequence
                       };
        }

        public IEnumerable<Event> GetEventsFor(Guid aggregateRootId)
        {
            return connection.Find<EventDocument>(Query.EQ("AggregateRootId", aggregateRootId.ToString())).Select(document => (Event) serializer.Deserialize(document.Event)).OrderBy(d => d.Sequence).ToList();
        }
    }
}
