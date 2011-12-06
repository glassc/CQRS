using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace CQRS.Configuration.NInject
{
    public static class NInjectContainerConfigurationExtension
    {
        public static Configure WithNInjectContainer(this Configure configure)
        {
            configure.Container(new NInjectContainer());
            return configure;
        }

        public static Configure  WithNInjectContainer(this Configure configure, IKernel kernel)
        {
            configure.Container(new NInjectContainer(kernel));
            return configure;
        }
    }
}
