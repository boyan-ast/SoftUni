using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] dragonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = dragonInfo[0];
                string name = dragonInfo[1];

                int damage = dragonInfo[2] == "null" ? 45 : int.Parse(dragonInfo[2]);
                int health = dragonInfo[3] == "null" ? 250 : int.Parse(dragonInfo[3]);
                int armor = dragonInfo[4] == "null" ? 10 : int.Parse(dragonInfo[4]);

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new SortedDictionary<string, int[]>();
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new int[3];
                }

                dragons[type][name][0] = damage;
                dragons[type][name][1] = health;
                dragons[type][name][2] = armor;
            }

            foreach (var globalKvp in dragons)
            {
                double averageDamage = globalKvp.Value.Sum(x => x.Value[0]) * 1.0 / globalKvp.Value.Count;
                double averageHealth = globalKvp.Value.Sum(x => x.Value[1]) * 1.0 / globalKvp.Value.Count;
                double averageArmor = globalKvp.Value.Sum(x => x.Value[2]) * 1.0 / globalKvp.Value.Count;

                Console.WriteLine($"{globalKvp.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var kvp in globalKvp.Value)
                {
                    Console.WriteLine($"-{kvp.Key} -> damage: {kvp.Value[0]}, health: {kvp.Value[1]}, armor: {kvp.Value[2]}");
                }
            }
        }
    }
}
