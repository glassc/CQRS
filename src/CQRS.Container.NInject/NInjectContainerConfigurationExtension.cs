using Ninject;

namespace CQRS.Container.NInject
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
