using DependencyInjectionWorkshop.Contracts;
using DependencyInjectionWorkshop.DI;
using DependencyInjectionWorkshop.DI.Containers;
using DependencyInjectionWorkshop.Loggers;
using System;

namespace DependencyInjectionWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new SnakeGameContainer();

            container.ConfigureServices();

            Injector injector = new Injector(container);

            Engine engine = injector.Inject<Engine>();

            engine.Start();
            engine.End();
        }
    }
}
