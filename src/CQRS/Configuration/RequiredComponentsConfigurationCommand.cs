using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Domain;

namespace CQRS.Configuration
{
   
    public class RequiredComponentsConfigurationCommand : IConfigureCommand
    {
        public void Run(IContainer container)
        {
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IDomainRepository, DomainRepository>();
        }
    }
}
