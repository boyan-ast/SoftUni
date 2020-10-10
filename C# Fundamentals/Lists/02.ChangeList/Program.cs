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
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();

                string action = tokens[0];
                int element = int.Parse(tokens[1]);

                if (action == "Delete")
                {
                    numbers.RemoveAll(nums => nums == element);
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
