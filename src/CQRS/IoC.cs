using CQRS.Configuration;

namespace CQRS
{
    public class IoC
    {
        private readonly IContainer container;
        private static IoC instance;

        private IoC(IContainer container)
        {
            this.container = container;
        }

        public static IContainer Container { get { return instance.container; } }

        public static void Set(IContainer container)
        {
            instance = new IoC(container);
        }
    }
}