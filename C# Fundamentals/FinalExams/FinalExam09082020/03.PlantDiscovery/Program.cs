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

            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = plantInfo[0];
                double rarity = double.Parse(plantInfo[1]);

                Plant existingPlant = plants.FirstOrDefault(x => x.Name == name);

                if (existingPlant == null)
                {
                    Plant newPlant = new Plant(name, rarity);
                    plants.Add(newPlant);
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
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                if (action == "Rate")
                {
                    string[] rateInfo = commandArgs[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plant = rateInfo[0];
                    double rating = double.Parse(rateInfo[1]);

                    Plant currentPlant = plants.FirstOrDefault(x => x.Name == plant);

                    if (currentPlant != null)
                    {
                        currentPlant.Ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Update")
                {
                    string[] updateInfo = commandArgs[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plant = updateInfo[0];
                    double newRarity = double.Parse(updateInfo[1]);

                    Plant plantToUpdate = plants.FirstOrDefault(x => x.Name == plant);

                    if (plantToUpdate != null)
                    {
                        plantToUpdate.Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Reset")
                {
                    string plant = commandArgs[1];

                    Plant plantToReset = plants.FirstOrDefault(x => x.Name == plant);

                    if (plantToReset != null)
                    {
                        plantToReset.Ratings.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine($"Plants for the exhibition:");
            foreach (Plant plant in plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.AverageRating()))
            {
                Console.WriteLine(plant);
            }

        }
    }

    class Plant
    {
        public string Name { get; set; }
        public double Rarity { get; set; }
        public List<double> Ratings { get; set; }

        public Plant(string name, double rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<double>();
        }

        public double AverageRating()
        {
            if (Ratings.Count == 0)
            {
                return 0;
            }
            else
            {
                return Ratings.Average();
            }
        }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {this.AverageRating():f2}";
        }
    }
}
