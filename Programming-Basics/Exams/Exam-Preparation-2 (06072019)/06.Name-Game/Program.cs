using System;

namespace _06.Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = null;

            string bestName = null;
            int bestScore = 0;

            while ((name = Console.ReadLine()) != "Stop")
            {
                int score = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    int num = int.Parse(Console.ReadLine());

                    if (num == name[i])
                    {
                        score += 10;
                    }
                    else
                    {
                        score += 2;
                    }
                }

                if (score >= bestScore)
                {
                    bestScore = score;
                    bestName = name;
                }
            }

            Console.WriteLine($"The winner is {bestName} with {bestScore} points!");
        }
    }
}
