using System;
using System.Collections.Generic;

namespace _05.Football_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int numberOfMatches = int.Parse(Console.ReadLine());

            if (numberOfMatches == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
                Environment.Exit(0);
            }

            Dictionary<char, int> statistics = new Dictionary<char, int>()
            {
                {'W', 0 },
                {'D', 0 },
                {'L', 0 }
            };

            int totalPoints = 0;

            for (int i = 0; i < numberOfMatches; i++)
            {
                char result = char.Parse(Console.ReadLine());

                if (result == 'W')
                {
                    totalPoints += 3;
                }
                else if (result == 'D')
                {
                    totalPoints++;
                }

                statistics[result]++;
            }

            Console.WriteLine($"{teamName} has won {totalPoints} points during this season.");
            Console.WriteLine("Total stats:");

            foreach (var result in statistics)
            {
                Console.WriteLine($"## {result.Key}: { result.Value}");
            }

            Console.WriteLine($"Win rate: {(statistics['W']*1.0/ numberOfMatches * 100):f2}%");
        }
    }
}
