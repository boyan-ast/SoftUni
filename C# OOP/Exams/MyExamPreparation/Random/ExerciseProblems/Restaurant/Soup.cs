using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Soup : MainDish
    {
        public Soup(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
}
