using DependencyInjectionWorkshop.DI.Attributes;
using DependencyInjectionWorkshop.DI.Containers;
using System;
using System.Linq;
using System.Reflection;

namespace DependencyInjectionWorkshop.DI
{
    public class Injector
    {
        private IContainer container;

        public Injector(IContainer container)
        {
            this.container = container;
        }

        public TClass Inject<TClass>()
        {
            if (!HasConstructorInjection<TClass>())
            {
                return (TClass)Activator.CreateInstance(typeof(TClass));

                //throw new ArgumentException("The class has no constructor annotated with Inject attribute");
            }

            return CreateConstructorInjection<TClass>();
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            ConstructorInfo[] constructors = typeof(TClass).GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(InjectAttribute), true) == null)
                {
                    continue;
                }

                ParameterInfo[] constructorParams = constructor.GetParameters();
                object[] constructorParamObjects = new object[constructorParams.Length];

                int i = 0;

                foreach (ParameterInfo parameterInfo in constructorParams)
                {
                    Type interfaceType = parameterInfo.ParameterType;
                    Type implementationType = container.GetMapping(interfaceType);

                    MethodInfo injectMethod = typeof(Injector).GetMethod("Inject");
                    injectMethod = injectMethod.MakeGenericMethod(implementationType);

                    object implementationInstance = injectMethod.Invoke(this, new object[] { });

                    constructorParamObjects[i++] = implementationInstance;
                }

                return (TClass)Activator.CreateInstance(typeof(TClass), constructorParamObjects);
            }

            return default;
        }

        private bool HasConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }
    }
}
