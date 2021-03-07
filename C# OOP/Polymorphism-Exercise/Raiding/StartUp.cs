using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();           


            while (heroes.Count < n)
            {
                string name = Console.ReadLine().TrimEnd();
                string type = Console.ReadLine().TrimEnd();

                if (type != nameof(Druid) 
                    && type != nameof(Paladin) 
                    && type != nameof(Rogue) 
                    && type != nameof(Warrior))
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                if (type == nameof(Druid))
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == nameof(Paladin))
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == nameof(Rogue))
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == nameof(Warrior))
                {
                    heroes.Add(new Warrior(name));
                }                
            }

            int heroesPower = heroes.Sum(h => h.Power);

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
