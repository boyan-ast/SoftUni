using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                ManipulateShoppingList(groceries, commandArgs);
            }

            Console.WriteLine(string.Join(", ", groceries));
        }

        private static void ManipulateShoppingList(List<string> groceries, string[] command)
        {
            string action = command[0];
            string item = command[1];
            int index = groceries.IndexOf(item);

            if (action == "Urgent")
            {
                if (index == -1)
                {
                    groceries.Insert(0, item);
                }
            }
            else if (action == "Unnecessary")
            {
                if (index != -1)
                {
                    groceries.Remove(item);
                }
            }
            else if (action == "Correct")
            {
                if (index != -1)
                {
                    groceries[index] = command[2];
                }
            }
            else if (action == "Rearrange")
            {
                if (index != -1)
                {
                    for (int i = index; i < groceries.Count - 1; i++)
                    {
                        groceries[i] = groceries[i + 1];
                    }

                    groceries[groceries.Count - 1] = item;
                }
            }
        }
    }
}
