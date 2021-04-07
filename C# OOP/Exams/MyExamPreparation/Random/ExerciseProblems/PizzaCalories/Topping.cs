using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double MeatTypeModifier = 1.2;
        private const double VeggiesTypeModifier = 0.8;
        private const double CheeseTypeModifier = 1.1;
        private const double SauceTypeModifier = 0.9;

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat" && 
                    value.ToLower() != "veggies" && 
                    value.ToLower() != "cheese" && 
                    value.ToLower() != "sauce")
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

        public double CaloriesPerGram => 2 * this.TypeModifier();

        public double TypeModifier()
        {
            if (this.Type.ToLower() == "meat")
            {
                return MeatTypeModifier;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                return VeggiesTypeModifier;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                return CheeseTypeModifier;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                return SauceTypeModifier;
            }

            return default;
        }
    }
}
