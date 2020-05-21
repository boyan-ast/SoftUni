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
                .Select(x => int.Parse(x))
                .ToList();

            string command = null;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                
                ListManipulationBasics(numbers, tokens);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ListManipulationBasics(List<int> numbers, string[] tokens)
        {
            if (tokens[0] == "Add")
            {
                int number = int.Parse(tokens[1]);
                numbers.Add(number);
            }
            else if (tokens[0] == "Remove")
            {
                int number = int.Parse(tokens[1]);
                numbers.RemoveAll(x => x == number);
            }
            else if (tokens[0] == "RemoveAt")
            {
                int index = int.Parse(tokens[1]);
                numbers.RemoveAt(index);
            }
            else if (tokens[0] == "Insert")
            {
                int number = int.Parse(tokens[1]);
                int index = int.Parse(tokens[2]);
                numbers.Insert(index, number);
            }
        }
    }
}
