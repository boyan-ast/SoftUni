using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> mixedList = new List<int>();

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                mixedList.Add(firstList[i]);
                mixedList.Add(secondList[secondList.Count - 1 - i]);
            }

            List<int> constrains = new List<int>();

            if (firstList.Count > secondList.Count)
            {
                constrains.Add(firstList[firstList.Count - 1]);
                constrains.Add(firstList[firstList.Count - 2]);
            }
            else
            {
                constrains.Add(secondList[0]);
                constrains.Add(secondList[1]);
            }

            constrains.Sort();

            int min = constrains[0];
            int max = constrains[1];

            List<int> result = mixedList
                .Where(x => (x > min && x < max))
                .OrderBy(n => n)
                .ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
