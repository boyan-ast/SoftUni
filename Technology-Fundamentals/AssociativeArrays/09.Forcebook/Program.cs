using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Forcebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputInfo = new string[2];
                string forceUser = string.Empty;
                string forceSide = string.Empty;

                bool forceUserExists = false;

                if (command.Split(" | ").Length == 2)
                {
                    inputInfo = command.Split(" | ");
                    forceSide = inputInfo[0];
                    forceUser = inputInfo[1];

                    foreach (var kvp in forceBook)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            forceUserExists = true;
                            break;
                        }
                    }

                    if (!forceUserExists)
                    {
                        if (!forceBook.ContainsKey(forceSide))
                        {
                            forceBook[forceSide] = new List<string>();
                        }

                        forceBook[forceSide].Add(forceUser);
                    }
                }
                else if (command.Split(" -> ").Length == 2)
                {
                    inputInfo = command.Split(" -> ");
                    forceSide = inputInfo[1];
                    forceUser = inputInfo[0];

                    foreach (var kvp in forceBook)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            forceUserExists = true;
                            kvp.Value.Remove(forceUser);
                            break;
                        }
                    }

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook[forceSide] = new List<string>();
                    }

                    forceBook[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var kvp in forceBook.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (string user in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
