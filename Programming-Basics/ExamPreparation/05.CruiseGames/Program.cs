using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CruiseGames
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());

            int volleyballGames = 0;
            int tennisGames = 0;
            int badmintonGames = 0;

            Dictionary<string, double> gamesScore = new Dictionary<string, double>()
            {
                { "volleyball", 0 },
                { "tennis", 0 },
                { "badminton", 0 }
            };

            for (int i = 0; i < games; i++)
            {
                string gameType = Console.ReadLine().ToLower();
                double score = double.Parse(Console.ReadLine());

                if (gameType != "volleyball" && gameType != "tennis" && gameType != "badminton")
                {
                    continue;
                }

                switch (gameType)
                {
                    case "volleyball":
                        volleyballGames++;
                        score *= 1.07;
                        break;
                    case "tennis":
                        tennisGames++;
                        score *= 1.05;
                        break;
                    case "badminton":
                        badmintonGames++;
                        score *= 1.02;
                        break;
                    default:
                        break;
                }

                gamesScore[gameType] += score;
            }

            double averageVolleyPoints = Math.Floor(gamesScore.Where(x => x.Key == "volleyball").Sum(y => y.Value) / volleyballGames);
            double averageTennisPoints = Math.Floor(gamesScore.Where(x => x.Key == "tennis").Sum(y => y.Value) / tennisGames);
            double averageBadmintonPoints = Math.Floor(gamesScore.Where(x => x.Key == "badminton").Sum(y => y.Value) / badmintonGames);

            double totalPoints = Math.Floor(gamesScore.Sum(x => x.Value));

            bool isWinning = (averageVolleyPoints >= 75.00) && (averageTennisPoints >= 75.00) && (averageBadmintonPoints >= 75.00);

            if (isWinning)
            {
                Console.WriteLine($"Congratulations, {player}! You won the cruise games with {totalPoints} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {player}, you lost. Your points are only {totalPoints}.");
            }
        }
    }
}
