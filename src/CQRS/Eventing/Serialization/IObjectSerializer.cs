using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Eventing.Serialization
{
    interface IEventSerializater
    {
        string Serialize(object objectToSerialize);
        object Deserialize(string raw);
    }
}
