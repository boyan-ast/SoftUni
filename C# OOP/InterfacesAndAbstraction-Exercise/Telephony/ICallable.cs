using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        string Number { get; set; }
        string Call();
    }
}
