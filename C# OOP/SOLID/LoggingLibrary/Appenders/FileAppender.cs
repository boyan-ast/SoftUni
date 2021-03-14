using LoggingLibrary.Enums;
using LoggingLibrary.Errors;
using LoggingLibrary.Layouts;
using LoggingLibrary.Loggers;

namespace LoggingLibrary.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, LogLevel logLevel, ILogFile logFile) 
            : base(layout, logLevel)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(IError error)
        {
            string dateTime = error.DateTime;
            LogLevel logLevel = error.LogLevel;
            string message = error.Message;

            this.LogFile.Write(string.Format(this.Layout.Format, dateTime, logLevel, message));

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.LogFile.Size}";
        }
    }
}
