using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.HeroesOfCodeAndLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = heroInfo[0];
                int hitPoints = int.Parse(heroInfo[1]);
                int manaPoints = int.Parse(heroInfo[2]);

                Hero hero = new Hero(name, manaPoints, hitPoints);

                heroes.Add(hero);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string heroName = commandArgs[1];

                Hero selectedHero = heroes.First(x => x.Name == heroName);

                if (action == "CastSpell")
                {
                    int neededMana = int.Parse(commandArgs[2]);
                    string spellName = commandArgs[3];

                    if (selectedHero.ManaPoints >= neededMana)
                    {
                        selectedHero.ManaPoints -= neededMana;

                        Console.WriteLine($"{selectedHero.Name} has successfully cast {spellName} and now has {selectedHero.ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{selectedHero.Name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(commandArgs[2]);
                    string attacker = commandArgs[3];

                    selectedHero.HitPoints -= damage;

                    if (selectedHero.HitPoints > 0)
                    {
                        Console.WriteLine($"{selectedHero.Name} was hit for {damage} HP by {attacker} and now has {selectedHero.HitPoints} HP left!");
                    }
                    else
                    {
                        heroes.Remove(selectedHero);

                        Console.WriteLine($"{selectedHero.Name} has been killed by {attacker}!");
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(commandArgs[2]);

                    if (selectedHero.ManaPoints + amount > 200)
                    {
                        amount = 200 - selectedHero.ManaPoints;
                    }

                    selectedHero.ManaPoints += amount;

                    Console.WriteLine($"{selectedHero.Name} recharged for {amount} MP!");
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(commandArgs[2]);

                    if (selectedHero.HitPoints + amount > 100)
                    {
                        amount = 100 - selectedHero.HitPoints;
                    }

                    selectedHero.HitPoints += amount;

                    Console.WriteLine($"{selectedHero.Name} healed for {amount} HP!");
                }
            }

            foreach (Hero hero in heroes.OrderByDescending(x => x.HitPoints).ThenBy(x => x.Name))
            {
                Console.WriteLine(hero);
            }
        }
    }

    class Hero
    {
        public string Name { get; set; }
        public int ManaPoints { get; set; }
        public int HitPoints { get; set; }

        public Hero(string name, int manaPoints, int hitPoints)
        {
            Name = name;
            ManaPoints = manaPoints;
            HitPoints = hitPoints;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(Name);
            output.AppendLine($"  HP: {HitPoints}");
            output.Append($"  MP: {ManaPoints}");

            return output.ToString();
        }
    }
}
