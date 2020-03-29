using System;

namespace _02.Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int extraExpensesPercent = int.Parse(Console.ReadLine());

            if (nights > 7)
            {
                pricePerNight *= 0.95;
            }

            double extraExpensesSum = budget * (extraExpensesPercent / 100.00);

            double totalSum = nights * pricePerNight + extraExpensesSum;

            if (totalSum > budget)
            {
                Console.WriteLine($"{(totalSum - budget):f2} leva needed.");
            }
            else
            {
                Console.WriteLine($"Ivanovi will be left with {(budget-totalSum):f2} leva after vacation.");
            }
        }
    }
}
