using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();

            while ((command = Console.ReadLine()) != "Sail")
            {
                string[] cityInfo = command
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string name = cityInfo[0];
                int population = int.Parse(cityInfo[1]);
                int gold = int.Parse(cityInfo[2]);

                if (!cities.ContainsKey(name))
                {
                    cities[name] = new int[2];
                }

                cities[name][0] += population;
                cities[name][1] += gold;
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string town = commandArgs[1];

                if (action == "Plunder")
                {
                    int people = int.Parse(commandArgs[2]);
                    int gold = int.Parse(commandArgs[3]);

                    if (cities.ContainsKey(town))
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        cities[town][0] -= people;
                        cities[town][1] -= gold;

                        if (cities[town][0] == 0 || cities[town][1] == 0)
                        {
                            cities.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(commandArgs[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    cities[town][1] += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                }
            }

            int count = cities.Count;
            if (count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {count} wealthy settlements to go to:");

                foreach (var kvp in cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
