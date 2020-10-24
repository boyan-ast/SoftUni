using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;
            int index = -1;

            while (int.TryParse(input = Console.ReadLine(), out index))
            {
                if (index < 0 || index >= targets.Count || targets[index] == -1)
                {                    
                    continue;
                }

                ShootTargets(targets, index);
            }

            int shotTargets = targets.Count(t => t == -1);

            Console.WriteLine($"Shot targets: {shotTargets} -> " + string.Join(" ", targets));
        }

        static void ShootTargets(List<int> targets, int index)
        {
            int targetValue = targets[index];
            targets[index] = -1;

            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] == -1)
                {
                    continue;
                }
                else
                {
                    if (targets[i] > targetValue)
                    {
                        targets[i] -= targetValue;
                    }
                    else
                    {
                        targets[i] += targetValue;
                    }
                }
            }
        }
    }
}
