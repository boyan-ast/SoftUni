using DependencyInjectionWorkshop.Contracts;
using DependencyInjectionWorkshop.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionWorkshop
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;

        [Inject]
        public Engine(ILogger logger, IReader reader)
        {
            this.logger = logger;
            this.reader = reader;
        }

        public void Start()
        {
            logger.Log("Game started!");

            reader.ReadKey();
            reader.ReadLine();
        }

        public void End()
        {
            logger.Log("Game ended!");
        }
    }
}
