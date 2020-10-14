using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            List<int> powers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            List<int> initialPowers = new List<int>(powers);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < powers.Count; i++)
                {
                    powers[i] -= hitPower;

                    if (powers[i] <= 0)
                    {
                        double drumPrice = initialPowers[i] * 3;

                        if ((budget - drumPrice) < 0)
                        {
                            powers.RemoveAt(i);
                            initialPowers.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            budget -= drumPrice;
                            powers[i] = initialPowers[i];
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", powers));
            Console.WriteLine($"Gabsy has {budget:f2}lv.");
        }
    }
}
