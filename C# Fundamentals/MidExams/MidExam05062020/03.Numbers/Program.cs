using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double averageValue = numbers.Sum() * 1.0 / numbers.Count;

            numbers.Sort();
            numbers.Reverse();

            List<int> filteredNumbers = new List<int>(5);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > averageValue && filteredNumbers.Count < 5)
                {
                    filteredNumbers.Add(numbers[i]);
                }
                else if (filteredNumbers.Count == 5)
                {
                    break;
                }
            }

            if (filteredNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", filteredNumbers));
            }
        }
    }
}
