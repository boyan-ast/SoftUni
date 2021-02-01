using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 1; i <= n; i++)
            {
                numbers[i - 1] = i;
            }

            int[] divisors = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> divisibilityChecker = IsDivisibleByAll;

            int[] resultNumbers = numbers.Where(x => divisibilityChecker(x, divisors)).ToArray();
            Console.WriteLine(string.Join(" ", resultNumbers));
        }

        static bool IsDivisibleByAll(int number, int[] divisors)
        {
            for (int i = 0; i < divisors.Length; i++)
            {
                if (number % divisors[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
