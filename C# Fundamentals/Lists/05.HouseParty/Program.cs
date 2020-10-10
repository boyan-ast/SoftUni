using System;
using System.Collections.Generic;

namespace _05.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int count = 0; count < numOfCommands; count++)
            {
                string[] command = Console.ReadLine().Split();

                ManageTheGuests(guests, command);
            }

            Console.WriteLine(string.Join("\n", guests));
        }

        private static void ManageTheGuests(List<string> guests, string[] command)
        {
            string name = command[0];

            if (command[2] == "going!")
            {
                if (guests.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else
                {
                    guests.Add(name);
                }
            }
            else if (command[2] == "not")
            {
                if (guests.Contains(name))
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
