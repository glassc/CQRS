using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS;
using CQRS.Configuration.NInject;
using CQRS.Eventing.Bus;
using CQRS.Eventing.Storage;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Do.Configure().WithNInjectContainer().WithSynchronizedEventBus().WithMemoryEventStore().Start();

        }
    }
}
