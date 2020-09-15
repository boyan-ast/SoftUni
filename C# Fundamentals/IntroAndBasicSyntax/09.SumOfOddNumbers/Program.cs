using System;

namespace _09.SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int number = 1;
            int sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                Console.WriteLine(number);
                sum += number;
                number += 2;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
