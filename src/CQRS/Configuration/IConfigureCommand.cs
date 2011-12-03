using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.Configuration
{
    public interface IConfigureCommand
    {
        void Run(IContainer container);
    }
}
