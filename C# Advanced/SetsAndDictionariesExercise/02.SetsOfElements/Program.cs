using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] numbersData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = numbersData[0];
            int m = numbersData[1];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
