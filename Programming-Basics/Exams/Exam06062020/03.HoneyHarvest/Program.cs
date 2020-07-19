using System;

namespace _03.HoneyHarvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] honeyHarvest =
            {
                { 10, 12, 12, 10 },
                { 8, 8, 8, 12},
                { 12, 6, 6, 6}
            };

            string flowerType = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            int honeyPerFlower = 0;

            if (flowerType == "Sunflower")
            {
                if (season == "Spring")
                {
                    honeyPerFlower = honeyHarvest[0, 0];
                }
                else if (season == "Summer")
                {
                    honeyPerFlower = honeyHarvest[1, 0];
                }
                else if (season == "Autumn")
                {
                    honeyPerFlower = honeyHarvest[2, 0];
                }
            }
            else if (flowerType == "Daisy")
            {
                if (season == "Spring")
                {
                    honeyPerFlower = honeyHarvest[0, 1];
                }
                else if (season == "Summer")
                {
                    honeyPerFlower = honeyHarvest[1, 1];
                }
                else if (season == "Autumn")
                {
                    honeyPerFlower = honeyHarvest[2, 1];
                }
            }
            else if (flowerType == "Lavender")
            {
                if (season == "Spring")
                {
                    honeyPerFlower = honeyHarvest[0, 2];
                }
                else if (season == "Summer")
                {
                    honeyPerFlower = honeyHarvest[1, 2];
                }
                else if (season == "Autumn")
                {
                    honeyPerFlower = honeyHarvest[2, 2];
                }
            }
            else if (flowerType == "Mint")
            {
                if (season == "Spring")
                {
                    honeyPerFlower = honeyHarvest[0, 3];
                }
                else if (season == "Summer")
                {
                    honeyPerFlower = honeyHarvest[1, 3];
                }
                else if (season == "Autumn")
                {
                    honeyPerFlower = honeyHarvest[2, 3];
                }
            }

            double totalHoneyVolume = numberOfFlowers * honeyPerFlower;

            if (season == "Summer")
            {
                totalHoneyVolume *= 1.1;
            }
            else if (season == "Autumn")
            {
                totalHoneyVolume *= 0.95;
            }
            else if (season == "Spring" && (flowerType == "Daisy" || flowerType == "Mint"))
            {
                totalHoneyVolume *= 1.1;
            }

            Console.WriteLine($"Total honey harvested: {totalHoneyVolume:f2}");
        }
    }
}
