using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] resultArr = new int[initialArr.Length];

            for (int i = 0; i < initialArr.Length; i++)
            {
                resultArr[i] = initialArr[i];
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "exchange")
                {
                    int index = int.Parse(tokens[1]);

                    if (index < 0 || index >= initialArr.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    ArrayRearrangor(initialArr, index, resultArr);
                }
                else if (tokens[0] == "max")
                {
                    int maxValueIndex = -1;

                    if (tokens[1] == "even")
                    {
                        maxValueIndex = GetMaxEvenOrOddElement(resultArr, 0);
                    }
                    if (tokens[1] == "odd")
                    {
                        maxValueIndex = GetMaxEvenOrOddElement(resultArr, 1);
                    }

                    if (maxValueIndex != -1)
                    {
                        Console.WriteLine(maxValueIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                }
                else if (tokens[0] == "min")
                {
                    int minValueIndex = -1;

                    if (tokens[1] == "even")
                    {
                        minValueIndex = GetMinEvenOrOddElement(resultArr, 0);
                    }
                    if (tokens[1] == "odd")
                    {
                        minValueIndex = GetMinEvenOrOddElement(resultArr, 1);
                    }

                    if (minValueIndex != -1)
                    {
                        Console.WriteLine(minValueIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (tokens[0] == "first")
                {
                    int count = int.Parse(tokens[1]);

                    if (count > initialArr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (tokens[2] == "even")
                    {
                        FirstEvenOrOddElementsPrinter(resultArr, count, 0);
                    }
                    else if (tokens[2] == "odd")
                    {
                        FirstEvenOrOddElementsPrinter(resultArr, count, 1);
                    }
                }
                else if (tokens[0] == "last")
                {
                    int count = int.Parse(tokens[1]);

                    if (count > initialArr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (tokens[2] == "even")
                    {
                        LastEvenOrOddElementsPrinter(resultArr, count, 0);
                    }
                    else if (tokens[2] == "odd")
                    {
                        LastEvenOrOddElementsPrinter(resultArr, count, 1);
                    }
                }
            }

            Console.WriteLine("["+string.Join(", ", resultArr) + "]");
        }

        private static void LastEvenOrOddElementsPrinter(int[] resultArr, int count, int reminder)
        {

            List<int> resultList = new List<int>();
            for (int i = resultArr.Length - 1; i >=0; i--)
            {
                if (resultArr[i] % 2 == reminder)
                {
                    if (count == 0)
                    {
                        break;
                    }
                    resultList.Add(resultArr[i]);
                    count--;
                }
            }

            resultList.Reverse();

            if (resultList.Count == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", resultList) + "]");
            }
        }

        private static void FirstEvenOrOddElementsPrinter(int[] resultArr, int count, int reminder)
        {

            List<int> resultList = new List<int>();
            for (int i = 0; i < resultArr.Length; i++)
            {
                if (resultArr[i] % 2 == reminder)
                {
                    if (count == 0)
                    {
                        break;
                    }
                    resultList.Add(resultArr[i]);
                    count--;
                }
            }

            if (resultList.Count == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("["+string.Join(", ", resultList) +"]");
            }
        }

        private static int GetMinEvenOrOddElement(int[] resultArr, int reminder)
        {
            int minValue = int.MaxValue;
            int minValueIndex = -1;

            for (int i = 0; i < resultArr.Length; i++)
            {
                if (resultArr[i] % 2 == reminder)
                {
                    if (resultArr[i] <= minValue)
                    {
                        minValueIndex = i;
                        minValue = resultArr[i];
                    }
                }
            }

            return minValueIndex;
        }

        private static int GetMaxEvenOrOddElement(int[] resultArr, int reminder)
        {
            int maxValue = int.MinValue;
            int maxValueIndex = -1;

            for (int i = 0; i < resultArr.Length; i++)
            {
                if (resultArr[i] % 2 == reminder)
                {
                    if (resultArr[i] >= maxValue)
                    {
                        maxValueIndex = i;
                        maxValue = resultArr[i];
                    }
                }
            }

            return maxValueIndex;
        }

        private static void ArrayRearrangor(int[] initialArr, int index, int[] resultArr)
        {
            int[] firstPart = resultArr.Take(index + 1).ToArray();
            int[] secondPart = resultArr.Skip(index + 1).ToArray();

            for (int i = 0; i < secondPart.Length; i++)
            {
                resultArr[i] = secondPart[i];
            }

            for (int j = secondPart.Length; j < resultArr.Length; j++)
            {
                resultArr[j] = firstPart[j - secondPart.Length];
            }
        }
    }
}
