﻿using LoggingLibrary.Appenders;
using LoggingLibrary.Enums;
using LoggingLibrary.Errors;
using System.Collections.Generic;
using System.Text;

namespace LoggingLibrary.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders 
            => (IReadOnlyCollection<IAppender>)this.appenders;


        public void Log(IError error)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (error.LogLevel >= appender.LogLevel)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
