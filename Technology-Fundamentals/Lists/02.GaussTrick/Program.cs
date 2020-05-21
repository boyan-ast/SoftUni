using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            List<int> resultList = new List<int>();

            for (int i = 0; i < (numbers.Count / 2); i++)
            {
                resultList.Add(numbers[i] + numbers[numbers.Count - 1 - i]);
            }

            if (numbers.Count % 2 != 0)
            {
                resultList.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
