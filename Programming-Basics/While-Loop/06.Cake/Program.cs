using System;
using System.Globalization;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int totalPieces = width * length;

            bool isEnough = true;

            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int pieces = int.Parse(command);
                totalPieces -= pieces;

                if (totalPieces <= 0)
                {
                    isEnough = false;
                    break;
                }
                command = Console.ReadLine();
            }

            if (isEnough)
            {
                Console.WriteLine($"{totalPieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {-totalPieces} pieces more.");
            }
        }
    }
}
