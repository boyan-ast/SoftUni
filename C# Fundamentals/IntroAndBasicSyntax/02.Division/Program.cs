using System;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] dividers = new int[] { 10, 7, 6, 3, 2 };

            for (int i = 0; i < dividers.Length; i++)
            {
                if (number % dividers[i] == 0)
                {
                    Console.WriteLine($"The number is divisible by {dividers[i]}");
                    return;
                }
            }

            Console.WriteLine("Not divisible");
        }
    }
}
