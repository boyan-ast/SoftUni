using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get; set;
        }

        public int ToppingsCount => this.toppings.Count;

        public double TotalCalories => this.CaloriesCalculator();

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        private double CaloriesCalculator()
        {
            double total = 0;

            total += this.Dough.CaloriesPerGram * this.Dough.Weight;

            foreach (Topping topping in this.toppings)
            {
                total += topping.CaloriesPerGram * topping.Weight;
            }

            return total;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
