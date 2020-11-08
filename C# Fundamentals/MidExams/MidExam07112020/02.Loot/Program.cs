using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Loot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loots = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                if (action == "Loot")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        string item = commandArgs[i];

                        if (!loots.Contains(item))
                        {
                            loots.Insert(0, item);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int index = int.Parse(commandArgs[1]);

                    if (index >= 0 && index < loots.Count)
                    {
                        string item = loots[index];
                        loots.RemoveAt(index);
                        loots.Add(item);
                    }
                }
                else if (action == "Steal")
                {
                    int count = int.Parse(commandArgs[1]);

                    if (count <= 0)
                    {
                        continue;
                    }
                    else if (count > loots.Count)
                    {
                        count = loots.Count;
                    }

                    List<string> stolenItems = new List<string>();

                    for (int i = 0; i < count; i++)
                    {
                        stolenItems.Add(loots[loots.Count - 1]);
                        loots.RemoveAt(loots.Count - 1);
                    }

                    stolenItems.Reverse();

                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }

            if (loots.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                int sumOfItems = 0;

                foreach (string item in loots)
                {
                    sumOfItems += item.Length;
                }

                double averageGain = sumOfItems * 1.0 / loots.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }
    }
}
