using LoggingLibrary.Appenders;
using LoggingLibrary.Core;
using LoggingLibrary.Enums;
using LoggingLibrary.Layouts;
using LoggingLibrary.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LoggingLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ILogger logger = SetUpLogger(n);

            IEngine engine = new Engine(logger);

            engine.Run();
        }

        private static ILogger SetUpLogger(int appendersCount)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];

                LogLevel appenderLogLevel = LogLevel.INFO;

                if (appendersInfo.Length == 3)
                {
                    bool isEnumValid = Enum.TryParse(typeof(LogLevel), appendersInfo[2], true, out object enumParsed);

                    if (!isEnumValid)
                    {
                        Console.WriteLine("Invalid level type");
                        continue;
                    }

                    appenderLogLevel = (LogLevel)enumParsed;                    
                }

                try
                {
                    ILayout layout = CreateLayout(layoutType);

                    IAppender appender = CreateAppender(appenderType, layout, appenderLogLevel, new LogFile());

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }

        private static IAppender CreateAppender(string appenderType, ILayout layout, LogLevel logLevel, ILogFile logFile)
        {
            IAppender appender = null;

            if (appenderType == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout, logLevel);
            }
            else if (appenderType == nameof(FileAppender) && logFile != null)
            {
                appender = new FileAppender(layout, logLevel, logFile);
            }
            else
            {
                throw new InvalidOperationException("Invalid Appender Type");
            }

            return appender;
        }

        private static ILayout CreateLayout(string layoutTypeString)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(layoutTypeString,
                StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException("Invalid Layout Type");
            }

            object[] ctorArgs = new object[] { };

            ILayout layout = (ILayout)Activator
                .CreateInstance(layoutType, ctorArgs);

            return layout;
        }


    }
}
