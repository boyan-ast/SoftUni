using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public int ToppingsCount
        {
            get => toppings.Count;
        }

        public Dough Dough
        {
            get => dough;
            set
            {
                dough = value;
            }
        }

        public double TotalCalories
        {
            get => CalculateTotalCalories();
        }

        public double CalculateTotalCalories()
        {
            double result = Dough.CalculateCalories();

            foreach (Topping topping in toppings)
            {
                result += topping.CalculateCalories();
            }

            return result;
        }
        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
