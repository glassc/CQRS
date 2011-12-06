using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace CQRS.Mongodb
{
    public interface IMongoConnection
    {
        void Insert<T>(T document);
        IEnumerable<T> Find<T>(IMongoQuery query);
    }
}