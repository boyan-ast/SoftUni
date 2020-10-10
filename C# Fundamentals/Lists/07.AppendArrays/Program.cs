using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allArraysToString = Console.ReadLine()
                .Split("|")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            StringBuilder result = new StringBuilder();

            for (int i = allArraysToString.Count - 1; i >= 0; i--)
            {
                int[] currentArray = allArraysToString[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                result.Append(string.Join(" ", currentArray));
                result.Append(" ");
            }

            Console.WriteLine(result);
        }
    }
}
