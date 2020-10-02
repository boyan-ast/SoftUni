using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "exchange")
                {
                    int index = int.Parse(tokens[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers = ExchangeArray(numbers, index);
                   
                }
                else if (tokens[0] == "max")
                {
                    string type = tokens[1];
                    int indexOfMaxEvenOrOdd = -1;

                    if (type == "even")
                    {
                        indexOfMaxEvenOrOdd = FindTheIndexOfMaxNum(numbers, 0);
                    }
                    else if (type == "odd")
                    {
                        indexOfMaxEvenOrOdd = FindTheIndexOfMaxNum(numbers, 1);
                    }
                    if (indexOfMaxEvenOrOdd == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(indexOfMaxEvenOrOdd);
                    }
                }
                else if (tokens[0] == "min")
                {
                    string type = tokens[1];
                    int indexOfMinEvenOrOdd = -1;

                    if (type == "even")
                    {
                        indexOfMinEvenOrOdd = FindTheIndexOfMinNum(numbers, 0);
                    }
                    else if (type == "odd")
                    {
                        indexOfMinEvenOrOdd = FindTheIndexOfMinNum(numbers, 1);
                    }

                    if (indexOfMinEvenOrOdd == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(indexOfMinEvenOrOdd);
                    }
                }
                else if (tokens[0] == "first")
                {
                    string type = tokens[2];
                    int count = int.Parse(tokens[1]);

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (type == "even")
                    {
                        PrintTheFirstEvensOrOdds(numbers, count, 0);
                    }
                    else if (type == "odd")
                    {
                        PrintTheFirstEvensOrOdds(numbers, count, 1);
                    }
                }
                else if (tokens[0] == "last")
                {
                    int count = int.Parse(tokens[1]);
                    string type = tokens[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (type == "even")
                    {
                        PrintLastEvensOrOdds(numbers, count, 0);
                    }
                    else if (type == "odd")
                    {
                        PrintLastEvensOrOdds(numbers, count, 1);
                    }
                }

            }

            Console.Write("[");
            Console.Write(string.Join(", ", numbers));
            Console.WriteLine("]");
        }

        private static void PrintLastEvensOrOdds(int[] numbers, int numberOfElements, int rem)
        {
            List<int> result = new List<int>();
            int count = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == rem && count < numberOfElements)
                {
                    result.Add(numbers[i]);
                    count++;
                }
            }

            result.Reverse();

            Console.Write("[");
            Console.Write(string.Join(", ", result));
            Console.WriteLine("]");
        }

        private static void PrintTheFirstEvensOrOdds(int[] numbers, int numOfElements, int rem)
        {
            StringBuilder result = new StringBuilder();

            int count = 0;
            result.Append("[");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == rem)
                {
                    if (count + 1 < numOfElements)
                    {
                        count++;
                        result.Append(numbers[i]);
                        result.Append(", ");
                    }
                    else if (count == numOfElements - 1)
                    {
                        result.Append(numbers[i]);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (result[result.Length - 1].ToString() == " ")
            {
                result.Remove(result.Length - 2, 2);

            }

            result.Append("]");

            Console.WriteLine(result);
        }

        private static int FindTheIndexOfMinNum(int[] numbers, int remainder)
        {
            int minNum = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == remainder && numbers[i] <= minNum)
                {
                    minNum = numbers[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private static int FindTheIndexOfMaxNum(int[] numbers, int remainder)
        {
            int maxNum = int.MinValue;
            int maxIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == remainder && numbers[i] >= maxNum)
                {
                    maxNum = numbers[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static int[] ExchangeArray(int[] numbers, int index)
        {
            int[] resultArray = new int[numbers.Length];

            for (int i = index + 1; i < numbers.Length; i++)
            {
                resultArray[i - index - 1] = numbers[i];
            }

            for (int j = 0; j <= index; j++)
            {
                resultArray[numbers.Length - 1 - index + j] = numbers[j];
            }

            return resultArray;
        }
    }
}
