using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}
