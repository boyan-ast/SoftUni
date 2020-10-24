using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                int index = int.Parse(tokens[1]);
                int value = int.Parse(tokens[2]);

                ManipulateTargets(targets, action, index, value);
            }

            Console.WriteLine(string.Join('|', targets));
        }

        static void ManipulateTargets(List<int> targets, string action, int index, int value)
        {
            switch (action)
            {
                case "Shoot":
                    if (index >= 0 && index < targets.Count)
                    {
                        if (targets[index] - value <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                        else
                        {
                            targets[index] -= value;
                        }
                    }
                    break;

                case "Add":
                    if (index < 0 || index >= targets.Count)
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else
                    {
                        targets.Insert(index, value);
                    }
                    break;

                case "Strike":
                    int startIndex = index - value;
                    int endIndex = index + value;

                    if (startIndex < 0 || startIndex >= targets.Count
                        || endIndex < 0 || endIndex >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange(startIndex, 2 * value + 1);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
