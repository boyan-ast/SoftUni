using LoggingLibrary.Enums;
using LoggingLibrary.Errors;
using LoggingLibrary.Layouts;

namespace LoggingLibrary.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        LogLevel LogLevel { get; }

        void Append(IError error);
    }
}
