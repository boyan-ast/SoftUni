using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            bool haveWinner = false;
            string winner = string.Empty;

            while (true)
            {
                string[] materials = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < materials.Length; i+=2)
                {
                    string material = materials[i].ToLower();
                    int quantity = int.Parse(materials[i - 1]);

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (CheckForWinner(keyMaterials))
                        {
                            haveWinner = true;

                            if (material == "shards")
                            {
                                winner = "Shadowmourne";
                            }
                            else if (material == "fragments")
                            {
                                winner = "Valanyr";
                            }
                            else
                            {
                                winner = "Dragonwrath";
                            }
                            keyMaterials[material] -= 250;
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

                if (haveWinner == true)
                {
                    break;
                }
            }

            Console.WriteLine($"{winner} obtained!");

            foreach (var kvp in keyMaterials.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var kvp in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }

        public static bool CheckForWinner(Dictionary<string, int> materials)
        {
            foreach (var kvp in materials)
            {
                if (kvp.Value >= 250)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
