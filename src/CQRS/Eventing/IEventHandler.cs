using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Eventing
{
    public interface IEventHandler<T> where T : Event
    {
        void Handle(T @event);
    }
}
