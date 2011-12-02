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

        public void Save(IEnumerable<Event> events)
        {
            using( var file = new FileStream(@"c:\event.store", FileMode.Append))
            {
                file.
            }
        
       
        }

        public IEnumerable<Event> GetEventsFor(Guid aggregateRootId)
        {
            throw new NotImplementedException();
        }
    }
}
