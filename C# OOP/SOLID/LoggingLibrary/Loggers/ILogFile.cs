using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingLibrary.Loggers
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
