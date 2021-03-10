using System;
using System.Collections.Generic;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace NewPostgresApp
{
   public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
         //   Bind<IContextFactory<ApplicationContext>>().To<ContextFactory>();
        }
    }
}
