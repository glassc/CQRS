using System;
using Ninject;

namespace CQRS.Configuration.NInject
{
    public class NInject
    {
        
        public static NInjectContainer Default
        {
            get
            {
                return new NInjectContainer();
            }
        }

        public static NInjectContainer Using(IKernel kernel)
        {
            return new NInjectContainer(kernel);
        }

        

    }
}