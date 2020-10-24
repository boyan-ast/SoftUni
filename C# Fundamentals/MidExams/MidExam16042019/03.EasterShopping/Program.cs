using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int n = int.Parse(Console.ReadLine());            

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                ExecuteCommands(shops, command);
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }

        private static void ExecuteCommands(List<string> shops, string[] command)
        {
            string action = command[0];
            if (action == "Include")
            {
                string newShop = command[1];
                shops.Add(newShop);
            }
            else if (action == "Visit")
            {
                int numberOfShops = int.Parse(command[2]);

                if (numberOfShops > shops.Count)
                {
                    return;
                }

                if (command[1] == "first")
                {
                    shops.RemoveRange(0, numberOfShops);
                }
                else if (command[1] == "last")
                {
                    shops.RemoveRange(shops.Count - numberOfShops, numberOfShops);
                }
            }
            else if (action == "Prefer")
            {
                int firstIndex = int.Parse(command[1]);
                int secondIndex = int.Parse(command[2]);

                if (firstIndex >= 0 && firstIndex < shops.Count && 
                    secondIndex >= 0 && secondIndex < shops.Count)
                {
                    string temp = shops[firstIndex];
                    shops[firstIndex] = shops[secondIndex];
                    shops[secondIndex] = temp;
                }
            }
            else if (action == "Place")
            {
                string newShop = command[1];
                int index = int.Parse(command[2]) + 1;

                if (index >= 0 && index < shops.Count)
                {
                    shops.Insert(index, newShop);
                }
            }
        }
    }
}
