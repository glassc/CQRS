using System;
using MongoDB.Bson;

namespace CQRS.Mongodb
{
    public class EventDocument
    {
        public ObjectId ObjectId { get; set;}
        public string EventId { get; set; }
        public int Sequence { get; set;}
        public string AggregateRootId { get; set;}
        public string Event { get; set;}

    }
}