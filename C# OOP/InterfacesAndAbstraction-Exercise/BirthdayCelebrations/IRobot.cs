using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
