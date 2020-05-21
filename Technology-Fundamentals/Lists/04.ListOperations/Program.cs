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
                .Select(x => int.Parse(x))
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] actions = command.Split();

                PerformOperation(numbers, actions);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void PerformOperation(List<int> numbers, string[] tokens)
        {
            string action = tokens[0];

            if (action == "Add")
            {
                int num = int.Parse(tokens[1]);
                numbers.Add(num);
            }
            else if (action == "Insert")
            {
                int num = int.Parse(tokens[1]);
                int index = int.Parse(tokens[2]);

                if (index < 0 || index >= numbers.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    numbers.Insert(index, num);
                }
            }
            else if (action == "Remove")
            {
                int index = int.Parse(tokens[1]);

                if (index < 0 || index >= numbers.Count)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    numbers.RemoveAt(index);
                }
            }
            else if (action == "Shift")
            {
                string direction = tokens[1];
                int count = int.Parse(tokens[2]);

                if (direction == "left")
                {
                    for (int i = 0; i < count; i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }
                }
                else if (direction == "right")
                {
                    for (int i = 0; i < count; i++)
                    {
                        numbers.Insert(0, numbers[numbers.Count - 1]);
                        numbers.RemoveAt((numbers.Count - 1));
                    }
                }


            }
        }

    }
}
