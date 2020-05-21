using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            List<int> resultList = new List<int>(firstList.Count + secondList.Count);
            int counter = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < counter; i++)
            {
                resultList.Add(firstList[0]);
                resultList.Add(secondList[0]);

                firstList.RemoveAt(0);
                secondList.RemoveAt(0);                    
            }

            if (firstList.Count > 0)
            {
                resultList.AddRange(firstList);
            }
            else if (secondList.Count > 0)
            {
                resultList.AddRange(secondList);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
