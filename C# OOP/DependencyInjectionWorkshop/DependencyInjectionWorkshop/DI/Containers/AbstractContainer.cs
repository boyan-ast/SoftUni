using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWorkshop.DI.Containers
{
    public abstract class AbstractContainer : IContainer
    {
        private Dictionary<Type, Type> mappings;

        public AbstractContainer()
        {
            this.mappings = new Dictionary<Type, Type>();
        }

        public abstract void ConfigureServices();

        public void CreateMapping<TInterfaceType, TImplementationType>()
        {
            if (!typeof(TInterfaceType).IsAssignableFrom(typeof(TImplementationType)))
            {
                throw new ArgumentException($"{typeof(TInterfaceType).Name} is not assignable from {typeof(TImplementationType).Name}");
            }

            this.mappings[typeof(TInterfaceType)] = typeof(TImplementationType);
        }

        public Type GetMapping(Type interfaceType)
        {
            return mappings[interfaceType];
        }
    }
}
