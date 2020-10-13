using System;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double firstTime = CalculateFirstTime(numbers);
            double secondTime = CalculateSecondTime(numbers);

            if (firstTime <= secondTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondTime}");
            }

        }

        private static double CalculateSecondTime(int[] numbers)
        {
            double sum = 0;

            for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
            {
                sum += numbers[i];

                if (numbers[i] == 0)
                {
                    sum *= 0.8;
                }
            }

            return sum;
        }

        private static double CalculateFirstTime(int[] numbers)
        {
            double sum = 0;

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                sum += numbers[i];

                if (numbers[i] == 0)
                {
                    sum *= 0.8;
                }
            }

            return sum;
        }
    }
}
