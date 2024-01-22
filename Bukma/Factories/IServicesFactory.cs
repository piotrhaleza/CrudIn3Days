using Autofac.Core;
using System;

namespace Bukma.Factories
{
    public interface IServicesFactory : IDisposable
    {
        T Create<T>(params Parameter[] parameters);
        T Create<T>(Enum enumek);
        object Create(Type type, params Parameter[] parameters);
    }
}