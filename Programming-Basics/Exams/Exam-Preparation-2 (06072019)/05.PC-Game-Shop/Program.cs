using System;
using System.Collections.Generic;

namespace _05.PC_Game_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> games = new Dictionary<string, int>
            {
                { "Hearthstone", 0 },
                { "Fornite", 0 },
                { "Overwatch", 0 },
                { "Others", 0 }
            };

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                if (name == "Hearthstone" || name == "Fornite" || name == "Overwatch")
                {
                    games[name]++;
                }
                else
                {
                    games["Others"]++;
                }
            }

            foreach (var game in games)
            {
                Console.WriteLine($"{game.Key} - {((double)(game.Value)/n * 100):f2}%");
            }

        }
    }
}
