using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildFarm
{
    static class Validator
    {
        public static bool ThrowIfCantEat(Food food, string animalType, params string[] foods)
        {
            if (!foods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{animalType} does not eat {food.GetType().Name}!");
            }

            return true;
        }
    }
}
