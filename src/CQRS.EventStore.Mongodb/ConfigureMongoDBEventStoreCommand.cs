using System;
using CQRS.Configuration;
using CQRS.Eventing.Storage;
using MongoDB.Bson.Serialization;

namespace CQRS.Mongodb
{
    public class ConfigureMongoDBEventStoreCommand : IConfigureCommand
    {
        private readonly string connectionString;

        public ConfigureMongoDBEventStoreCommand(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Run(IContainer container)
        {
            RegisterComponents(container);
            MapEventClassToDocument.Map();
        }

        private void RegisterComponents(IContainer container)
        {
            container.Register<IMongoConnection>(new MongoConnection(connectionString));
            container.Register<IEventStore, MongoDBEventStore>();
        }

   
    }
}