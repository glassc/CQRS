using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CQRS.Mongodb
{
    public class MapEventClassToDocument
    {
        public static void Map()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(EventDocument))) return;
            BsonClassMap.RegisterClassMap<EventDocument>(m =>
            {
                m.MapIdField(c => c.ObjectId).SetIdGenerator(ObjectIdGenerator.Instance);
                m.MapProperty(c => c.AggregateRootId).SetIsRequired(true);
                m.MapProperty(c => c.Sequence).SetIsRequired(true);
                m.MapProperty(c => c.Event).SetIsRequired(true);
                m.MapProperty(c => c.EventId).SetIsRequired(true);
            });

            
        }
    }
}