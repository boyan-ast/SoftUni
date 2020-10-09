using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            string command = string.Empty;

            bool hasChanged = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add"
                    || tokens[0] == "Remove"
                    || tokens[0] == "RemoveAt"
                    || tokens[0] == "Insert")
                {
                    hasChanged = true;
                }

                ManipulateList(tokens, numbers);
            }

            if (hasChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void ManipulateList(string[] command, List<int> numbers)
        {
            string action = command[0];

            int num = 0;
            int index = -1;

            switch (action)
            {
                case "Add":
                    num = int.Parse(command[1]);
                    numbers.Add(num);
                    break;
                case "Remove":
                    num = int.Parse(command[1]);
                    numbers.RemoveAll(x => x == num);
                    break;
                case "RemoveAt":
                    index = int.Parse(command[1]);
                    numbers.RemoveAt(index);
                    break;
                case "Insert":
                    num = int.Parse(command[1]);
                    index = int.Parse(command[2]);
                    numbers.Insert(index, num);
                    break;
                case "Contains":
                    num = int.Parse(command[1]);
                    if (numbers.Contains(num))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                    break;
                case "PrintEven":
                    List<int> evenNums = numbers.Where(x => x % 2 == 0).ToList();
                    Console.WriteLine(string.Join(" ", evenNums));
                    break;
                case "PrintOdd":
                    List<int> oddNums = numbers.Where(x => x % 2 == 1).ToList();
                    Console.WriteLine(string.Join(" ", oddNums));
                    break;
                case "GetSum":
                    int sum = numbers.Sum();
                    Console.WriteLine(sum);
                    break;
                case "Filter":
                    string condition = command[1];
                    num = int.Parse(command[2]);
                    PrintFulfillingNums(numbers, condition, num);
                    break;
                default:
                    break;
            }
        }

        private static void PrintFulfillingNums(List<int> numbers, string condition, int num)
        {
            List<int> result = new List<int>();

            switch (condition)
            {
                case "<":
                    result = numbers.Where(x => x < num).ToList();
                    break;
                case ">":
                    result = numbers.Where(x => x > num).ToList();
                    break;
                case ">=":
                    result = numbers.Where(x => x >= num).ToList();
                    break;
                case "<=":
                    result = numbers.Where(x => x <= num).ToList();
                    break;
                default:
                    break;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

