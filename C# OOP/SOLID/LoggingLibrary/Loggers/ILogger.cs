using LoggingLibrary.Appenders;
using LoggingLibrary.Errors;
using System.Collections.Generic;

namespace LoggingLibrary.Loggers
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}