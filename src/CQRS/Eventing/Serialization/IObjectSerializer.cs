using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Eventing.Serialization
{
    public interface IObjectSerializer
    {
        string Serialize(object objectToSerialize);
        object Deserialize(string raw);
    }
}
