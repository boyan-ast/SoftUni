using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingUsers = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string username = command[1];

                if (command[0] == "register")
                {
                    string plateNumber = command[2];
                    RegisterUser(username, plateNumber, parkingUsers);
                }
                else
                {
                    UnregisterUser(username, parkingUsers);
                }
            }

            foreach (var kvp in parkingUsers)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }

        private static void UnregisterUser(string user, Dictionary<string, string> parkingUsers)
        {
            if (parkingUsers.ContainsKey(user))
            {
                Console.WriteLine($"{user} unregistered successfully");
                parkingUsers.Remove(user);
            }
            else
            {
                Console.WriteLine($"ERROR: user {user} not found");
            }
        }

        private static void RegisterUser(string user, string number, Dictionary<string, string> parkingUsers)
        {
            if (parkingUsers.ContainsKey(user))
            {
                Console.WriteLine($"ERROR: already registered with plate number {number}");
            }
            else
            {
                Console.WriteLine($"{user} registered {number} successfully");
                parkingUsers.Add(user, number);
            }
        }
    }
}
