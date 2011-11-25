using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Configuration
{
    public interface IContainer 
    {
        void Register<Ti, To>() where To : Ti;
        void Register<T>(T instance);
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
        IEnumerable ResolveAll(Type type);
        
    }
}
