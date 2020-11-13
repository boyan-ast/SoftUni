using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonsInfo = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Demon> allDemons = new List<Demon>(demonsInfo.Length);

            string healthPattern = @"[^0-9\+\-\*\/\.]";
            string numsPattern = @"[\+\-]?\d+(\.\d+)?";

            foreach (string name in demonsInfo)
            {
                var chars = Regex.Matches(name, healthPattern);
                int health = 0;

                foreach (Match match in chars)
                {
                    health += char.Parse(match.Value);
                }

                var nums = Regex.Matches(name, numsPattern);
                double damage = 0;

                foreach (Match match in nums)
                {
                    damage += double.Parse(match.Value);
                }

                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i]=='*')
                    {
                        damage *= 2;
                    }
                    else if (name[i] == '/')
                    {
                        damage /= 2.00;
                    }
                }

                Demon demon = new Demon(name, health, damage);
                allDemons.Add(demon);
            }

            foreach (Demon demon in allDemons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }

        }
    }

    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
