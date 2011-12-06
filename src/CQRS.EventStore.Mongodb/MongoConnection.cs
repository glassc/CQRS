using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace CQRS.Mongodb
{
    public class MongoConnection : IMongoConnection
    {
        private readonly string connectionString;
        private readonly string databaseName;

        public MongoConnection(string connectionString)
        {
            var builder = new MongoUrlBuilder(connectionString);

            this.connectionString = connectionString;
            databaseName = builder.DatabaseName;
        }

       
        public void Insert<T>(T document)
        {
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase(databaseName);
            var collectionName = typeof (T).Name;
            var collection = database.GetCollection<T>(collectionName);
            collection.Insert(document);
        }

        public IEnumerable<T> Find<T>(IMongoQuery query)
        {
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase(databaseName);
            var collectionName = typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            return collection.Find(query);
        }

        public T Get<T>(IMongoQuery query)
        {
            
        }
    }
}