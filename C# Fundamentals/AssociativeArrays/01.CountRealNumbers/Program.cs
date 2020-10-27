using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Dictionary<int, int> counts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!counts.ContainsKey(numbers[i]))
                {
                    counts[numbers[i]] = 0;
                }
                counts[numbers[i]]++;
            }

            foreach (var kvp in counts.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
