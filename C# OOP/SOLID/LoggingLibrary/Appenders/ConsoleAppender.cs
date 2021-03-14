using LoggingLibrary.Enums;
using LoggingLibrary.Errors;
using LoggingLibrary.Layouts;
using System;

namespace LoggingLibrary.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, LogLevel logLevel) 
            : base(layout, logLevel)
        {
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            string dateTime = error.DateTime;
            string message = error.Message;
            LogLevel logLevel = error.LogLevel;

            string formattedString = String.Format(format, dateTime, logLevel, message);

            Console.WriteLine(formattedString);

            this.messagesAppended++;
        }
    }
}
