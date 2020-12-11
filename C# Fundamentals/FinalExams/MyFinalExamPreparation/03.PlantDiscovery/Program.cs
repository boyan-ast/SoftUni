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
            List<Plant> allPlants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string name = plantInfo[0];
                int rarity = int.Parse(plantInfo[1]);

                Plant existingPlant = allPlants.FirstOrDefault(p => p.Name == name);

                if (existingPlant == null)
                {
                    Plant newPlant = new Plant(name, rarity);
                    allPlants.Add(newPlant);
                }
                else
                {
                    existingPlant.Rarity = rarity;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] commandArgs = command
                    .Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string name = commandArgs[1];

                Plant existingPlant = allPlants.FirstOrDefault(p => p.Name == name);

                if (existingPlant == null)
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (action == "Rate")
                {
                    existingPlant.Ratings.Add(double.Parse(commandArgs[2]));
                }
                else if (action == "Update")
                {
                    existingPlant.Rarity = int.Parse(commandArgs[2]);
                }
                else if (action == "Reset")
                {
                    existingPlant.Ratings.Clear();
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine($"Plants for the exhibition:");

            List<Plant> orderedPlants = allPlants
                .Select(x => {
                    if (x.Ratings.Count == 0)
                    {
                        x.Ratings.Add(0);
                    }
                    return x;
                })
                .OrderByDescending(x => x.Rarity)
                .ThenByDescending(x => x.Ratings.Average())
                .ToList();

        
            foreach (Plant plant in orderedPlants)
            {
                Console.WriteLine(plant);
            }
        }
    }

    class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Ratings { get; set; }

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<double>();
        }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {Ratings.Average():f2}";
        }
    }
}
