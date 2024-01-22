using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukma.Factories
{
    public class ServicesFactory : IServicesFactory
    {
        protected readonly ILifetimeScope _scope;

        public ServicesFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public T Create<T>(params Parameter[] parameters)
        {
            return _scope.Resolve<T>(parameters);
        }
        public T Create<T>(Enum enumek)
        {
            return _scope.ResolveKeyed<T>(enumek);
        }
        public object Create(Type type, params Parameter[] parameters)
        {
            return _scope.Resolve(type, parameters);
        }

        public void Dispose()
        {
           
        }
    }
}
