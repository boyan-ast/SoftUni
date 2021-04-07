using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Topping
    {
        private double weight;
        private string type;


        public string Type
        {
            get => this.type;
            private set
            {
                if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight 
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
    }
}
