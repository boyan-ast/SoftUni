using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();
            List<string> allUsers = new List<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                List<string> tokens = new List<string>();
                string action = string.Empty;

                if (command.Contains(" | "))
                {
                    tokens = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    action = "add";
                }
                else if (command.Contains(" -> "))
                {
                    tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    action = "change";
                }

                if (action == "add" && tokens.Count >= 2)
                {
                    AddUser(forceSides, allUsers, tokens[0], tokens[1]);
                }
                else if (action == "change" && tokens.Count >= 2)
                {
                    string forceUser = tokens[0];
                    string newForceSide = tokens[1];

                    if (allUsers.Contains(forceUser))
                    {
                        string oldForceSide = forceSides.FirstOrDefault(x => x.Value.Contains(forceUser)).Key;

                        if (!forceSides.ContainsKey(newForceSide))
                        {
                            forceSides[oldForceSide].Remove(forceUser);
                            forceSides.Add(newForceSide, new List<string>());
                            forceSides[newForceSide].Add(forceUser);
                        }
                        else if (oldForceSide != newForceSide)
                        {
                            forceSides[oldForceSide].Remove(forceUser);
                            forceSides[newForceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        AddUser(forceSides, allUsers, newForceSide, forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {newForceSide} side!");
                }
            }

            var filteredSides = forceSides
                .Where(x => x.Value.Count != 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            foreach (var kvp in filteredSides)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (string user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static void AddUser(Dictionary<string, List<string>> forces, List<string> users, string forceSide, string forceUser)
        {
            if (!forces.ContainsKey(forceSide))
            {
                forces.Add(forceSide, new List<string>());
            }

            if (!users.Contains(forceUser))
            {
                forces[forceSide].Add(forceUser);
                users.Add(forceUser);
            }
        }
    }
}
