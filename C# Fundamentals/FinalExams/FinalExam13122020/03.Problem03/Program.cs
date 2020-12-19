using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fighter> allFighters = new List<Fighter>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Results")
            {
                string[] commandArgs = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string name = commandArgs[1];

                Fighter selectedFighter = allFighters.FirstOrDefault(x => x.Name == name);

                if (action == "Add")
                {
                    int health = int.Parse(commandArgs[2]);
                    int energy = int.Parse(commandArgs[3]);

                    if (selectedFighter == null)
                    {
                        Fighter newFighter = new Fighter(name, health, energy);
                        allFighters.Add(newFighter);
                    }
                    else
                    {
                        selectedFighter.Health += health;
                    }
                }
                else if (action == "Attack")
                {
                    string defenderName = commandArgs[2];
                    int damage = int.Parse(commandArgs[3]);

                    Fighter selectedDefender = allFighters.FirstOrDefault(x => x.Name == defenderName);

                    if (selectedDefender != null && selectedFighter != null)
                    {
                        selectedDefender.Health -= damage;

                        if (selectedDefender.Health <= 0)
                        {
                            Console.WriteLine($"{defenderName} was disqualified!");
                            allFighters.Remove(selectedDefender);
                        }

                        selectedFighter.Energy--;

                        if (selectedFighter.Energy == 0)
                        {
                            Console.WriteLine($"{name} was disqualified!");
                            allFighters.Remove(selectedFighter);
                        }
                    }
                }
                else if (action == "Delete")
                {
                    if (selectedFighter != null)
                    {
                        allFighters.Remove(selectedFighter);
                    }
                    else if (name == "All")
                    {
                        allFighters.Clear();
                    }
                }
            }

            Console.WriteLine($"People count: {allFighters.Count}");

            foreach (Fighter fighter in allFighters.OrderByDescending(f => f.Health).ThenBy(f => f.Name))
            {
                Console.WriteLine(fighter);
            }
        }
    }

    class Fighter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }

        public Fighter(string name, int health, int energy)
        {
            Name = name;
            Health = health;
            Energy = energy;
        }

        public override string ToString()
        {
            return $"{Name} - {Health} - {Energy}";
        }
    }
}
