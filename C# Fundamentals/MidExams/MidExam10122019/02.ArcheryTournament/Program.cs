using System;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int points = 0;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] tokens = command.Split('@', StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];

                if (direction == "Reverse")
                {
                    targets = targets.Reverse().ToArray();
                    continue;
                }

                int startIndex = int.Parse(tokens[1]);
                int length = int.Parse(tokens[2]);

                if (startIndex < 0 || startIndex >= targets.Length)
                {
                    continue;
                }

                int endIndex = startIndex;

                if (direction == "Shoot Left")
                {
                    for (int i = 0; i < length; i++)
                    {
                        endIndex--;

                        if (endIndex == -1)
                        {
                            endIndex = targets.Length - 1;
                        }
                    }
                }
                else if (direction == "Shoot Right")
                {
                    for (int i = 0; i < length; i++)
                    {
                        endIndex++;

                        if (endIndex == targets.Length)
                        {
                            endIndex = 0;
                        }
                    }
                }

                if (targets[endIndex] < 5)
                {
                    points += targets[endIndex];
                    targets[endIndex] = 0;
                }
                else
                {
                    targets[endIndex] -= 5;
                    points += 5;
                }
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
