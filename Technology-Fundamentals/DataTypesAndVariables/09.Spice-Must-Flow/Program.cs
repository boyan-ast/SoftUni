using System;

namespace _09.Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalAmount = 0;

            while (startingYield >= 100)
            {
                days++;
                totalAmount += startingYield - 26;
                startingYield -= 10;
            }

            if (totalAmount >= 26)
            {
                totalAmount -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}
