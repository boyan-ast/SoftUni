using LoggingLibrary.Enums;
using LoggingLibrary.Errors;
using LoggingLibrary.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingLibrary.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string logLevelStr = errorArgs[0];
                string dateTime = errorArgs[1];
                string message = errorArgs[2];                

                bool isLevelValid = Enum.TryParse(typeof(LogLevel), logLevelStr, true, out object logLevelObj);

                if (!isLevelValid)
                {
                    Console.WriteLine("Invalid Level");
                    continue;
                }

                LogLevel logLevel = (LogLevel)logLevelObj;

                IError error = new Error(dateTime, message, logLevel);

                this.logger.Log(error);
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
