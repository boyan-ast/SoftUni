using System;

namespace _02.Summer_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double towelPrice = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double umbrellaPrice = (2 * towelPrice) / 3;
            double flipFlopsPrice = 0.75 * umbrellaPrice;
            double bagPrice = 1d / 3 * (flipFlopsPrice + towelPrice);

            double totalExpenses = (towelPrice + umbrellaPrice + flipFlopsPrice + bagPrice) * (100 - discount) / 100d;

            if (budget >= totalExpenses)
            {
                Console.WriteLine($"Annie's sum is {totalExpenses:f2} lv. She has {(budget-totalExpenses):f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {totalExpenses:f2} lv. She needs {(totalExpenses-budget):f2} lv. more.");
            }
        }
    }
}
