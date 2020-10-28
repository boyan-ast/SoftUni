using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));                
        }
    }
}
