using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allArrays = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            allArrays.Reverse();
            List<int> numbers = new List<int>();

            foreach (string item in allArrays)
            {
                int[] array = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                numbers.AddRange(array);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}