using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double price = 0;

            while (destination != "End")
            {
                price = double.Parse(Console.ReadLine());
                double currentSum = 0;

                while (currentSum < price)
                {
                    double savings = double.Parse(Console.ReadLine());
                    currentSum += savings;
                }

                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();
            }
        }
    }
}
