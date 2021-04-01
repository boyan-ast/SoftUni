using DependencyInjectionWorkshop.Contracts;
using DependencyInjectionWorkshop.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWorkshop.Readers
{
    public class ConsoleReader : IReader
    {
        private ILogger logger;

        [Inject]
        public ConsoleReader(ILogger logger)
        {
            this.logger = logger;
        }

        public string ReadKey()
        {
            logger.Log("Reading key");

            return "";
        }

        public string ReadLine()
        {
            logger.Log("Reading line");

            return "";
        }
    }
}
