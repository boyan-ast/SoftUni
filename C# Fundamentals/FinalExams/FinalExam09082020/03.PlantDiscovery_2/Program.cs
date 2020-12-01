using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string name = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                if (!plants.ContainsKey(name))
                {
                    plants[name] = new List<double>();
                    plants[name].Add(rarity);
                }
                else
                {
                    plants[name][0] = rarity;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exhibition")
            {
                bool hasError = false;

                string[] commandArgs = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                if (action == "Rate")
                {
                    string[] rateInfo = commandArgs[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plant = rateInfo[0];
                    int rating = int.Parse(rateInfo[1]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Add(rating);
                    }
                    else
                    {
                        hasError = true;
                    }
                }
                else if (action == "Update")
                {
                    string[] updateInfo = commandArgs[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plant = updateInfo[0];
                    int newRarity = int.Parse(updateInfo[1]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant][0] = newRarity;
                    }
                    else
                    {
                        hasError = true;
                    }

                }
                else if (action == "Reset")
                {
                    string plant = commandArgs[1];
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].RemoveRange(1, plants[plant].Count - 1);
                    }
                    else
                    {
                        hasError = true;
                    }
                }
                else
                {
                    hasError = true;
                }

                if (hasError)
                {
                    Console.WriteLine("error");
                }
            }

            foreach (var kvp in plants)
            {
                if (kvp.Value.Count == 1)
                {
                    kvp.Value.Add(0);
                }
                else
                {
                    kvp.Value.Add(kvp.Value.Skip(1).Take(kvp.Value.Count - 1).Select(x => x).Average());
                }

            }

            Console.WriteLine($"Plants for the exhibition:");

            foreach (var kvp in plants.OrderByDescending(x => x.Value[0])
                .ThenByDescending(x => x.Value[x.Value.Count - 1]))
            {
                Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value[0]}; Rating: {kvp.Value[kvp.Value.Count - 1]:f2}");
            }
        }
    }
}
