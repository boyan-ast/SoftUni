using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type 
        {
            get => type;
            private set
            {
                if (value.ToLower() != "meat" 
                    && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" 
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        public double Weight 
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 2 * weight;

            if (Type.ToLower() == "meat")
            {
                calories *= Meat;
            }
            else if (Type.ToLower() == "veggies")
            {
                calories *= Veggies;
            }
            else if (Type.ToLower() == "cheese")
            {
                calories *= Cheese;
            }
            else if (Type.ToLower() == "sauce")
            {
                calories *= Sauce;
            }

            return calories;
        }

    }
}
