using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {

        public string Browse(string site)
        {
            if (IsInvalidSite(site))
            {
                throw new InvalidOperationException("Invalid URL!");
            }

            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (IsInvalidNumber(number))
            {
                throw new InvalidOperationException("Invalid number!");
            }

            return $"Calling... {number}";
        }


        private bool IsInvalidSite(string site)
        {
            foreach (char symbol in site)
            {
                if (char.IsDigit(symbol))
                {
                    return true;
                }
            }

            return false;
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
