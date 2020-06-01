using System;
using System.Collections.Generic;

namespace _06.BakingCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int competitors = int.Parse(Console.ReadLine());
            double totalSum = 0;
            int sweetsCounter = 0;

            for (int i = 0; i < competitors; i++)
            {
                Dictionary<string, int> sweets = new Dictionary<string, int>()
                {
                    { "cookies", 0 },
                    { "cakes", 0 },
                    { "waffles", 0 }
                };

                string name = Console.ReadLine();
                string type = string.Empty;

                while ((type = Console.ReadLine()) != "Stop baking!")
                {
                    int numberOfSweets = int.Parse(Console.ReadLine());
                    sweetsCounter += numberOfSweets;

                    sweets[type] += numberOfSweets;
                }

                Console.WriteLine($"{name} baked {sweets["cookies"]} cookies, {sweets["cakes"]} cakes and {sweets["waffles"]} waffles.");

                totalSum += (sweets["cookies"] * 1.5 + sweets["cakes"] * 7.8 + sweets["waffles"] * 2.3);
            }

            Console.WriteLine($"All bakery sold: {sweetsCounter}");
            Console.WriteLine($"Total sum for charity: {totalSum:f2} lv.");

        }
    }
}
