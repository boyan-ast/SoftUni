using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string type = Console.ReadLine();

            int start = boundaries[0];
            int end = boundaries[1];

            if (start > end)
            {
                end = boundaries[0];
                start = boundaries[1];
            }

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> filter = EvenOrOdd(type);

            List<int> result = numbers.FindAll(filter);

            Console.WriteLine(string.Join(" ", result));
        }        

        private static Predicate<int> EvenOrOdd(string type)
        {
            switch (type)
            {
                case "odd": return n => n % 2 != 0;
                case "even": return n => n % 2 == 0;
                default: return null;
            }
        }
      
    }
}
