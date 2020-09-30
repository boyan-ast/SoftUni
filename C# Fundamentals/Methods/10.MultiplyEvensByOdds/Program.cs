using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            GetMultipleOfEvenAndOdds(Math.Abs(number));
        }

        private static void GetMultipleOfEvenAndOdds(int number)
        {
            int sumOfEvenDigits = GetSumOfDigits(number, 0);
            int sumOfOddDigits = GetSumOfDigits(number, 1);

            Console.WriteLine(sumOfEvenDigits * sumOfOddDigits);
        }

        private static int GetSumOfDigits(int number, int remainder)
        {
            int sum = 0;

            while (number != 0)
            {
                if ((number % 10) % 2 == remainder)
                {
                    sum += number % 10;
                }
                number /= 10;
            }

            return sum;
        }
    }
}
