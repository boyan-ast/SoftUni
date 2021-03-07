using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            eatableFoods = new string[] { nameof(Vegetable), nameof(Fruit) };
            foodFactor = 0.10;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
