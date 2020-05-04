using System;

namespace _02.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string showType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double income = 0;

            int seats = rows * cols;

            if (showType == "Premiere")
            {
                income = seats * 12;
            }
            else if (showType == "Normal")
            {
                income = seats * 7.5;
            }
            else if (showType == "Discount")
            {
                income = seats * 5;
            }

            Console.WriteLine($"{income:f2} leva");
        }
    }
}
