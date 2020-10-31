using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSides = new Dictionary<string, List<string>>();

            ManageTheForceUsers(forceSides);

            PrintTheForceSides(forceSides);
        }

        private static void PrintTheForceSides(Dictionary<string, List<string>> sides)
        {
            Dictionary<string, List<string>> filteredSides = sides
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in filteredSides)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (string user in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static void ManageTheForceUsers(Dictionary<string, List<string>> sides)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains(" | "))
                {
                    string[] userInfo = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    bool userExists = false;

                    foreach (var kvp in sides)
                    {
                        if (kvp.Value.Contains(userInfo[1]))
                        {
                            userExists = true;
                            break;
                        }
                    }

                    if (!userExists)
                    {
                        AddNewUser(sides, userInfo[0], userInfo[1]);
                    }
                }
                else if (command.Contains(" -> "))
                {
                    string[] userInfo = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    ChangeSides(sides, userInfo[0], userInfo[1]);
                }
            }
        }

        private static void ChangeSides(Dictionary<string, List<string>> sides, string forceUser, string forceSide)
        {
            bool exists = false;
            string currentSide = string.Empty;

            foreach (var kvp in sides)
            {
                if (kvp.Value.Contains(forceUser))
                {
                    exists = true;
                    currentSide = kvp.Key;
                    break;
                }
            }

            if (exists)
            {
                sides[currentSide].Remove(forceUser);
            }

            AddNewUser(sides, forceSide, forceUser);

            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
        }

        private static void AddNewUser(Dictionary<string, List<string>> sides, string forceSide, string forceUser)
        {

            if (!sides.ContainsKey(forceSide))
            {
                sides[forceSide] = new List<string>();
            }

            sides[forceSide].Add(forceUser);
        }
    }
}
