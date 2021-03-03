using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        private string number;

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

        public string Call()
        {
            return $"Dialing... {Number}";
        }
    }
}
