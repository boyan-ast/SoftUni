using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            eatableFoods = new string[] { nameof(Meat), nameof(Vegetable), nameof(Fruit), nameof(Seeds) };
            foodFactor = 0.35;
        }
       

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
