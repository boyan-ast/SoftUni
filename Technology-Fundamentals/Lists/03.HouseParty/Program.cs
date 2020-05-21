using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                AddOrRemoveGuests(guests, command);
            }

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }

        private static void AddOrRemoveGuests(List<string> guests, string[] command)
        {
            string name = command[0];
            bool isThere = false;

            if (guests.Contains(name))
            {
                isThere = true;
            }

            if (command.Length == 3)
            {
                if (!isThere)
                {
                    guests.Add(name);
                }
                else
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
            }
            else if (command.Length == 4)
            {
                if (isThere)
                {
                    guests.Remove(name);
                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }
    }
}
