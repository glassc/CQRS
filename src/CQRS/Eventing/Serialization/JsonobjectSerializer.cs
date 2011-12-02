using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CQRS.Eventing.Serialization
{
    public class JsonObjectSerializer : IEventSerializater
    {
        private readonly JsonSerializer serializer;

        public JsonObjectSerializer()
        {
            this.serializer = new JsonSerializer
                                  {
                                      TypeNameHandling = TypeNameHandling.Auto;

                                  }
            
        }

        public string Serialize(object objectToSerialize)
        {
            return JObject.FromObject(objectToSerialize).ToString();
        }

        public object Deserialize(string raw)
        {
            var json = JObject.Parse(raw);
            return serializer.Deserialize(json.CreateReader());
        }
    }
}