using System;

namespace _06.Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothesPrice = double.Parse(Console.ReadLine());

            double decorPrice = 0.1 * budget;
            double totalClothesPrice = statists * clothesPrice;

            if (statists > 150)
            {
                totalClothesPrice *= 0.9;
            }

            double moneyDifference = budget - (decorPrice + totalClothesPrice);

            if (moneyDifference >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyDifference:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {-moneyDifference:f2} leva more.");
            }
        }
    }
}
