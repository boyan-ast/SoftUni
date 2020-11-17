using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Dragon> allDragons = new List<Dragon>();

            for (int i = 0; i < n; i++)
            {
                string[] dragonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = dragonInfo[0];
                string name = dragonInfo[1];

                int damage = 0;
                if (!int.TryParse(dragonInfo[2], out damage))
                {
                    damage = 45;
                }

                int health = 0;
                if (!int.TryParse(dragonInfo[3], out health))
                {
                    health = 250;
                }

                int armor = 0;
                if (!int.TryParse(dragonInfo[4], out armor))
                {
                    armor = 10;
                }


                Dragon existingOne = allDragons.FirstOrDefault(x => (x.Type == type && x.Name == name));

                if (existingOne != null)
                {
                    existingOne.Health = health;
                    existingOne.Damage = damage;
                    existingOne.Armor = armor;
                }
                else
                {
                    Dragon newOne = new Dragon(name, type, damage, health, armor);
                    allDragons.Add(newOne);
                }
            }            

            Dictionary<string, List<Dragon>> dragonsByType = new Dictionary<string, List<Dragon>>();

            foreach (Dragon dragon in allDragons)
            {
                string type = dragon.Type;

                if (!dragonsByType.ContainsKey(type))
                {
                    dragonsByType[type] = new List<Dragon>();
                }

                dragonsByType[type].Add(dragon);
            }

            foreach (var kvp in dragonsByType)
            {
                double averageDamage = kvp.Value.Average(x => x.Damage);
                double averageHealth = kvp.Value.Average(x => x.Health);
                double averageArmor = kvp.Value.Average(x => x.Armor);

                Console.WriteLine($"{kvp.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (Dragon dragon in kvp.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }

    class Dragon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string name, string type, int damage, int health, int armor)
        {
            Name = name;
            Type = type;
            Damage = damage;
            Health = health;
            Armor = armor;
        }
    }
}
