using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
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

            while ((command = Console.ReadLine()) != "end")
            {
                string[] actions = command.Split();              

                ChangeList(numbers, actions);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ChangeList(List<int> numbers, string[] tokens)
        {
            string action = tokens[0];
            int element = int.Parse(tokens[1]);

            if (action == "Delete")
            {
                numbers.RemoveAll(x => x == element);
            }
            else if (action == "Insert")
            {
                int position = int.Parse(tokens[2]);
                numbers.Insert(position, element);
            }
        }
    }
}
