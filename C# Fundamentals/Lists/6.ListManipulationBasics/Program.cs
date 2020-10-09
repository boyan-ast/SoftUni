using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
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

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                ManipulateList(tokens, numbers);
            }

            Console.WriteLine(string.Join(" ", numbers));
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
                default:
                    break;
            }
        }
    }
}
