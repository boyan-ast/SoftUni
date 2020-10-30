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

                int endIndex = -1;

                if (direction == "Shoot Left")
                {
                    if (length == 0)
                    {
                        endIndex = targets.Length - (startIndex + 1);
                    }
                    else
                    {
                        endIndex = targets.Length - (startIndex + length);

                        if (endIndex < 0)
                        {
                            while (endIndex < 0)
                            {
                                length -= targets.Length;
                                endIndex = targets.Length - (startIndex + length);
                            }
                        }
                    }
                }
                else if (direction == "Shoot Right")
                {
                    endIndex = startIndex + length;

                    if (endIndex >= targets.Length)
                    {
                        while (endIndex >= targets.Length)
                        {
                            length -= targets.Length;
                            endIndex = startIndex + length;
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
