using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] commandArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                ManipulateItems(items, commandArgs);
            }

            Console.WriteLine(string.Join(", ", items));
        }

        private static void ManipulateItems(List<string> items, string[] commandArgs)
        {
            string action = commandArgs[0];
            string item = commandArgs[1];

            if (action == "Collect")
            {
                if (!items.Contains(item))
                {
                    items.Add(item);
                }
            }
            else if (action == "Drop")
            {
                if (items.Contains(item))
                {
                    items.Remove(item);
                }
            }
            else if (action == "Combine Items")
            {
                string[] combinationItems = item.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string oldItem = combinationItems[0];
                string newItem = combinationItems[1];

                int oldItemIndex = items.IndexOf(oldItem);

                if (oldItemIndex != -1)
                {
                    items.Insert(oldItemIndex + 1, newItem);
                }
            }
            else if (action == "Renew")
            {
                if (items.Contains(item))
                {
                    int index = items.IndexOf(item);

                    for (int i = index; i < items.Count - 1; i++)
                    {
                        items[i] = items[i + 1];
                    }

                    items[items.Count - 1] = item;
                }
            }

        }
    }
}
