using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicTable = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int k = 0; k < elements.Length; k++)
                {
                    periodicTable.Add(elements[k]);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
