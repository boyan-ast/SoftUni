using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                ManipulateList(numbers, tokens);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ManipulateList(List<int> numbers, string[] tokens)
        {
            string action = tokens[0];
            int number = 0;
            int index = -1;

            if (action == "Add")
            {
                number = int.Parse(tokens[1]);
                numbers.Add(number);
            }
            else if (action == "Insert")
            {
                number = int.Parse(tokens[1]);
                index = int.Parse(tokens[2]);

                if (CheckTheIndex(index, numbers.Count))
                {
                    numbers.Insert(index, number);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (action == "Remove")
            {
                index = int.Parse(tokens[1]);

                if (CheckTheIndex(index, numbers.Count))
                {
                    numbers.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (action == "Shift")
            {
                string direction = tokens[1];
                int count = int.Parse(tokens[2]);
                ShiftTheNumbers(numbers, direction, count);
            }
        }

        private static void ShiftTheNumbers(List<int> numbers, string direction, int count)
        {
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int firstNum = numbers[0];

                    for (int j = 0; j < numbers.Count - 1; j++)
                    {
                        numbers[j] = numbers[j + 1];
                    }

                    numbers[numbers.Count - 1] = firstNum;
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < count; i++)
                {
                    int lastNum = numbers[numbers.Count - 1];

                    for (int j = numbers.Count - 1; j > 0; j--)
                    {
                        numbers[j] = numbers[j - 1];
                    }

                    numbers[0] = lastNum;
                }
            }
        }

        private static bool CheckTheIndex(int index, int length)
        {
            if (index < 0 || index >= length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
