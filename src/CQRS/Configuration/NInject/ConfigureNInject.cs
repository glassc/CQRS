using Ninject;

namespace CQRS.Configuration.NInject
{
    public static class ConfigureNInject
    {
        public static Configure NInject(this Configure configuration)
        {
          
            return configuration.Using(new NInjectContainer()); 
        }

        public static Configure NInject(this Configure configuration, IKernel kernel)
        {
            return configuration.Using(new NInjectContainer(kernel)); 
        }
    }
}