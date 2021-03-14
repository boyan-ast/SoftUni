using LoggingLibrary.Enums;

namespace LoggingLibrary.Errors
{
    public interface IError
    {
        string DateTime { get; }

        string Message { get; }

        LogLevel LogLevel { get; }
    }
}
