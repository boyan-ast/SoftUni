using System;

namespace _04.DartsTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            int moves = 0;

            while (points > 0)
            {
                moves++;
                string sectorType = Console.ReadLine();

                if (sectorType == "bullseye")
                {
                    Console.WriteLine($"Congratulations! You won the game with a bullseye in {moves} moves!");
                    return;
                }

                int currentPoints = int.Parse(Console.ReadLine());

                if (sectorType == "double ring")
                {
                    currentPoints *= 2;
                }
                else if (sectorType == "triple ring")
                {
                    currentPoints *= 3;
                }

                points -= currentPoints;
            }

            if (points == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {moves} moves!");
            }
            else
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(points)}.");
            }
        }
    }
}
