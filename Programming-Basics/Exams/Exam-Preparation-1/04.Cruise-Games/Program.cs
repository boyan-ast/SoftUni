using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Cruise_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int plyedGames = int.Parse(Console.ReadLine());

            int volleyballGames = 0;
            int tennisGames = 0;
            int badmintonGames = 0;

            double volleyballPoints = 0d;
            double tennisPoints = 0d;
            double badmintonPoints = 0d;

            for (int i = 0; i < plyedGames; i++)
            {
                string gameType = Console.ReadLine().ToLower();
                int points = int.Parse(Console.ReadLine());

                if (gameType == "volleyball")
                {
                    volleyballGames++;
                    volleyballPoints += 1.07 * points;
                }
                else if (gameType == "tennis")
                {
                    tennisGames++;
                    tennisPoints += 1.05 * points;
                }
                else if (gameType == "badminton")
                {
                    badmintonGames++;
                    badmintonPoints += 1.02 * points;
                }
            }

            double averageVolleyballPoints = Math.Floor(volleyballPoints / volleyballGames);
            double averageTennisPoints = Math.Floor(tennisPoints / tennisGames);
            double averageBadmintonPoints = Math.Floor(badmintonPoints / badmintonGames);

            double totalPoints = Math.Floor(volleyballPoints + tennisPoints + badmintonPoints);

            if (averageTennisPoints >= 75 && averageTennisPoints >= 75 && averageBadmintonPoints >= 75)
            {
                Console.WriteLine($"Congratulations, {name}! You won the cruise games with {totalPoints} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {name}, you lost. Your points are only {totalPoints}.");
            }

        }

    }
}
