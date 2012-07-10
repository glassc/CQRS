using CQRS.Mongodb;

namespace CQRS
{
    public static class MongoDBConfigurationExtension
    {
        public static Configure UsingMongoDB(this Configure configure, string connectionString)
        {
            configure.AddCommand(new ConfigureMongoDBEventStoreCommand(connectionString));
            return configure;
        }
    }
}
