using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();
            CollectItems(legendaryItems, junkMaterials);
            PrintRemainingItems(legendaryItems, junkMaterials);
        }

        private static void PrintRemainingItems(Dictionary<string, int> legendaryItems, Dictionary<string, int> junkMaterials)
        {
            foreach (var kvp in legendaryItems.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static void CollectItems(Dictionary<string, int> legendaryItems, Dictionary<string, int> junkMaterials)
        {
            bool hasWinner = false;
            string winnerMaterial = string.Empty;

            while (true)
            {
                string[] itemsInfo = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < itemsInfo.Length; i += 2)
                {
                    string material = itemsInfo[i];
                    int quantity = int.Parse(itemsInfo[i - 1]);

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material] >= 250)
                        {
                            hasWinner = true;
                            winnerMaterial = material;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }

                        junkMaterials[material] += quantity;
                    }                    

                }

                if (hasWinner)
                {
                    legendaryItems[winnerMaterial] -= 250;

                    if (winnerMaterial == "motes")
                    {                                                
                        Console.WriteLine("Dragonwrath obtained!");
                    }
                    else if (winnerMaterial == "shards")
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                    }
                    else
                    {
                        Console.WriteLine("Valanyr obtained!");
                    }

                    break;
                }
            }
        }
    }
}
