using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CQRS.Eventing.Serialization;

namespace CQRS.Eventing.Storage
{
    public class SimpleFileStore : IEventStore
    {
        private readonly IObjectSerializer serializer;

        public SimpleFileStore(IObjectSerializer serializer)
        {
            this.serializer = serializer;
        }

        public void Save(IEnumerable<Event> events)
        {
            using( var file = new StreamWriter(new FileStream(@"c:\event.store", FileMode.Append)))
            {
                foreach (var @event in events)
                
                    file.WriteLine(serializer.Serialize(@event));
                
                
            }
        
       
        }

        public IEnumerable<Event> GetEventsFor(Guid aggregateRootId)
        {
            var result = new List<Event>();
            using (var file = new StreamReader(new FileStream(@"c:\event.store", FileMode.Append)))
            {
               while(!file.EndOfStream)
               {
                   result.Add((Event)serializer.Deserialize(file.ReadLine()));
               }


            }
            return result;
        }
    }
}
