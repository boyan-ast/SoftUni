using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int counter = Math.Min(firstArr.Count, secondArr.Count);

            List<int> resultList = new List<int>(firstArr.Count + secondArr.Count);

            for (int i = 0; i < counter; i++)
            {
                resultList.Add(firstArr[0]);
                resultList.Add(secondArr[0]);

                firstArr.RemoveAt(0);
                secondArr.RemoveAt(0);
            }

            if (firstArr.Count != 0)
            {
                resultList.AddRange(firstArr);
            }
            else if (secondArr.Count != 0)
            {
                resultList.AddRange(secondArr);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
