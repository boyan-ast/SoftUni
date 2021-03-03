using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public static class Validator
    {
        public static bool IsValidNumber(string number, string invalidNumberMessage)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException(invalidNumberMessage);
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    throw new ArgumentException(invalidNumberMessage);
                }
            }

            return true;
        }

        public static bool IsValidURL(string url, string invalidURLMessage)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(invalidURLMessage);
            }

            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    throw new ArgumentException(invalidURLMessage);
                }
            }

            return true;
        }
    }
}
