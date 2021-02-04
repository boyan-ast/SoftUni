using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ingredientsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> ingredients = new Stack<int>(ingredientsInput);

            SortedDictionary<string, int> foods = new SortedDictionary<string, int>()
            {
                { "Bread", 0},
                { "Cake", 0},
                { "Fruit Pie", 0},
                { "Pastry", 0 }
            };


            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();

                string cookedFood = TryToCook(currentLiquid, currentIngredient);

                if (cookedFood == null)
                {
                    currentIngredient += 3;
                    ingredients.Push(currentIngredient);
                }
                else
                {
                    foods[cookedFood]++;
                }
            }

            if (foods.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            Console.Write("Liquids left: ");

            if (liquids.Count > 0)
            {
                Console.WriteLine(string.Join(", ", liquids));
            }
            else
            {
                Console.WriteLine("none");
            }

            Console.Write("Ingredients left: ");

            if (ingredients.Count > 0)
            {
                Console.WriteLine(string.Join(", ", ingredients));
            }
            else
            {
                Console.WriteLine("none");
            }

            foreach ((string food, int count)in foods)
            {
                Console.WriteLine($"{food}: {count}");
            }
        }

        private static string TryToCook(int liquid, int ingredient)
        {
            int sum = liquid + ingredient;

            switch (sum)
            {
                case 25: return "Bread";
                case 50: return "Cake";
                case 75: return "Pastry";
                case 100: return "Fruit Pie";
                default: return null;
            }
        }
    }
}
