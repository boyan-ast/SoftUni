using System;

namespace _02.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCardsCount = int.Parse(Console.ReadLine());
            int cpuCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());

            bool discount = videoCardsCount > cpuCount;

            double videoCardsPrice = videoCardsCount * 250;
            double cpuPrice = (0.35 * videoCardsPrice) * cpuCount;
            double ramPrice = (0.1 * videoCardsPrice) * ramCount;

            double totalPrice = videoCardsPrice + cpuPrice + ramPrice;

            if (discount)
            {
                totalPrice *= 0.85;
            }

            if (totalPrice > budget)
            {
                Console.WriteLine($"Not enough money! You need {(totalPrice-budget):f2} leva more!");
            }
            else
            {
                Console.WriteLine($"You have {(budget-totalPrice):f2} leva left!");
            }
        }
    }
}
