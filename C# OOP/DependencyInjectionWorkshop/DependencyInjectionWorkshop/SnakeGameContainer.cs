using DependencyInjectionWorkshop.Contracts;
using DependencyInjectionWorkshop.DI.Containers;
using DependencyInjectionWorkshop.Loggers;
using DependencyInjectionWorkshop.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWorkshop
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            this.CreateMapping<ILogger, ConsoleLogger>();
            this.CreateMapping<IReader, ConsoleReader>();
        }
    }
}
