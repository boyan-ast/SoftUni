using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    interface IRebel : IPerson, IBuyer
    {
        string Group { get; }
    }
}
