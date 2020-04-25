using System;

namespace _08.Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());

            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double totalSum = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;

            int toys = puzzles + dolls + bears + minions + trucks;

            if (toys >= 50)
            {
                totalSum *= 0.75;
            }

            totalSum *= 0.9;

            if (totalSum >= tripPrice)
            {
                Console.WriteLine($"Yes! {(totalSum - tripPrice):f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(tripPrice - totalSum):f2} lv needed.");
            }

        }
    }
}
