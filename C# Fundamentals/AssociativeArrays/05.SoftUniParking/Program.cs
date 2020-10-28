using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cars = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];
                string username = command[1];

                if (action == "register")
                {
                    string plateNumber = command[2];

                    if (cars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {cars[username]}");
                    }
                    else
                    {
                        cars.Add(username, plateNumber);
                        Console.WriteLine($"{username} registered {plateNumber} successfully");
                    }
                }
                else if (action == "unregister")
                {
                    if (!cars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        cars.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in cars)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
