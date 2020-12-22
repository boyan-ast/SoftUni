using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counter = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!counter.ContainsKey(numbers[i]))
                {
                    counter.Add(numbers[i], 0);
                }

                counter[numbers[i]]++;
            }

            foreach (var kvp in counter)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
