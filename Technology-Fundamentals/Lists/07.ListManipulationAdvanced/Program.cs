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

            bool hasChanged = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                
                ListManipulationBasics(numbers, tokens, hasChanged);
            }

            if (hasChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }            
        }

        private static void ListManipulationBasics(List<int> numbers, string[] tokens, bool hasChanged)
        {
            if (tokens[0] == "Add")
            {
                hasChanged = true;
                int number = int.Parse(tokens[1]);
                numbers.Add(number);
            }
            else if (tokens[0] == "Remove")
            {
                hasChanged = true;
                int number = int.Parse(tokens[1]);
                numbers.RemoveAll(x => x == number);
            }
            else if (tokens[0] == "RemoveAt")
            {
                hasChanged = true;
                int index = int.Parse(tokens[1]);
                numbers.RemoveAt(index);
            }
            else if (tokens[0] == "Insert")
            {
                hasChanged = true;
                int number = int.Parse(tokens[1]);
                int index = int.Parse(tokens[2]);
                numbers.Insert(index, number);
            }
            else if (tokens[0] == "Contains")
            {
                if (numbers.Contains(int.Parse(tokens[1])))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No such number");
                }
            }
            else if (tokens[0] == "PrintEven")
            {
                List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
                Console.WriteLine(string.Join(" ", evenNumbers));
            }
            else if (tokens[0] == "PrintOdd")
            {
                List<int> oddNumbers = numbers.Where(x => x % 2 != 0).ToList();
                Console.WriteLine(string.Join(" ", oddNumbers));
            }
            else if (tokens[0] == "GetSum")
            {
                Console.WriteLine(numbers.Sum());
            }
            else if (tokens[0] == "Filter")
            {
                ListFilter(numbers, tokens[1], int.Parse(tokens[2]));
            }
        }

        private static void ListFilter(List<int> numbers, string condition, int number)
        {
            List<int> filteredList = new List<int>();

            if (condition == "<")
            {
                filteredList = numbers.Where(x => x < number).ToList();
            }
            else if (condition == ">")
            {
                filteredList = numbers.Where(x => x > number).ToList();
            }
            else if (condition == ">=")
            {
                filteredList = numbers.Where(x => x >= number).ToList();
            }
            else if (condition == "<=")
            {
                filteredList = numbers.Where(x => x <= number).ToList();
            }

            Console.WriteLine(string.Join(" ", filteredList));
        }
    }
}
