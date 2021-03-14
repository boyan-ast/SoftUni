using LoggingLibrary.Enums;
using LoggingLibrary.Errors;
using LoggingLibrary.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingLibrary.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppended;

        protected Appender(ILayout layout, LogLevel logLevel)
        {
            this.Layout = layout;
            this.LogLevel = logLevel;
        }

        public ILayout Layout { get; }

        public LogLevel LogLevel { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.LogLevel.ToString()}, " +
                $"Messages appended: {this.messagesAppended}";
        }
    }
}
