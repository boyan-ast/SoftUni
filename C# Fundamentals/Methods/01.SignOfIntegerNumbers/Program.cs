using System;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(NumberSign(number));
        }

        private static string NumberSign(int number)
        {
            string sign = string.Empty;

            if (number > 0)
            {
                sign = "positive";
            }
            else if (number < 0)
            {
                sign = "negative";
            }
            else
            {
                sign = "zero";
            }

            return $"The number {number} is {sign}.";
        }
    }
}
