using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace CQRS.Configuration.NInject
{
    public static class NInjectContainerConfigurationExtension
    {
        public static CQRS WithNInjectContainer(this CQRS cqrs)
        {
            cqrs.Container(new NInjectContainer());
            return cqrs;
        }

        public static CQRS  WithNInjectContainer(this CQRS cqrs, IKernel kernel)
        {
            cqrs.Container(new NInjectContainer(kernel));
            return cqrs;
        }
    }
}
