using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowsable
    {
        string URL { get; set; }

        string Browse();
    }
}
