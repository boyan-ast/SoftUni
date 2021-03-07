using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            eatableFoods = new string[] { nameof(Vegetable), nameof(Meat) };
            foodFactor = 0.30;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
