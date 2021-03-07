using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        protected string[] eatableFoods;
        protected double foodFactor;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();
                
        internal void Eat(Food food)
        {
            if (Validator.ThrowIfCantEat(food, this.GetType().Name, this.eatableFoods))
            {
                this.Weight += food.Quantity * this.foodFactor;
                this.FoodEaten += food.Quantity;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
