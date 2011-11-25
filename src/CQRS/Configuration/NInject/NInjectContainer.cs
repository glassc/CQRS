using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace CQRS.Configuration.NInject
{
    public class NInjectContainer : IContainer
    {
        private readonly IKernel kernel;

        public NInjectContainer() : this(new StandardKernel())
        {
        }

        public NInjectContainer(IKernel kernel)
        {
            this.kernel = kernel;

        }

        
        public void Register<Ti, To>() where To : Ti
        {
            kernel.Bind<Ti>().To<To>().InSingletonScope();
        }

        public void Register<T>(T instance)
        {
            kernel.Bind<T>().ToConstant(instance).InSingletonScope();
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return kernel.GetAll<T>();
        }

        public IEnumerable ResolveAll(Type type)
        {
            return kernel.GetAll(type);
        }
    }
}
