using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(x => double.Parse(x)).ToArray();
            Dictionary<double, int> numbersCounter = new Dictionary<double, int>();

            foreach (double num in numbers)
            {
                if (!numbersCounter.ContainsKey(num))
                {
                    numbersCounter[num] = 0;
                }

                numbersCounter[num]++;
            }

            foreach (var kvp in numbersCounter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
