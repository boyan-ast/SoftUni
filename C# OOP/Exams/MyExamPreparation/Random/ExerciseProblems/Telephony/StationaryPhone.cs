using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (IsInvalidNumber(number))
            {
                throw new InvalidOperationException("Invalid number!");
            }

            return $"Dialing... {number}";
        }

        private bool IsInvalidNumber(string number)
        {
            foreach (char digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
