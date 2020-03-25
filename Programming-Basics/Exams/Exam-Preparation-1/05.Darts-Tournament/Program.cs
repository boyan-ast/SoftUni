using System;

namespace _05.Darts_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPoints = int.Parse(Console.ReadLine());

            int moves = 0;

            while (totalPoints > 0)
            {
                string sectorType = Console.ReadLine();
                moves++;

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

                totalPoints -= currentPoints;

                if (totalPoints == 0)
                {
                    Console.WriteLine($"Congratulations! You won the game in {moves} moves!");
                    return;
                }
                
            }

            Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(totalPoints)}.");
        }
    }
}
