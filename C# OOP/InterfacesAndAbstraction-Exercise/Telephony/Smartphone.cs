using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string number;
        private string url;
        public string Number 
        {
            get => this.number;
            set
            {
                if (Validator.IsValidNumber(value, "Invalid number!"))
                {
                    this.number = value;
                }
            }
        }

        public string URL 
        { 
            get => this.url; 
            set
            {
                if (Validator.IsValidURL(value, "Invalid URL!"))
                {
                    this.url = value;
                }
            }
        }

        public string Browse()
        {
            return $"Browsing: {URL}!";
        }

        public string Call()
        {
            return $"Calling... {Number}";
        }
    }
}
