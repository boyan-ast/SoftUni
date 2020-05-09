using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int increases = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int i = 0; i < increases; i++)
            {
                double sum = double.Parse(Console.ReadLine());
                if (sum < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {sum:f2}");
                totalSum += sum;
            }

            Console.WriteLine($"Total: {totalSum:f2}");

        }
    }
}
