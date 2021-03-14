using LoggingLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingLibrary.Errors
{
    public class Error : IError
    {
        public Error(string dateTime, string message, LogLevel logLevel)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.LogLevel = logLevel;
        }

        public string DateTime { get; }

        public string Message { get; }

        public LogLevel LogLevel { get; }
    }
}
