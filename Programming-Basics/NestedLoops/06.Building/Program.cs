using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            string[,] building = new string[floors, rooms];

            for (int row = 0; row < floors; row++)
            {
                for (int column = 0; column < rooms; column++)
                {
                    if (row == 0)
                    {
                        building[row, column] = "L" + (floors - row) + column;
                    }
                    else if ((floors - row) % 2 == 0)
                    {
                        building[row, column] = "O" + (floors - row) + column;
                    }
                    else
                    {
                        building[row, column] = "A" + (floors - row) + column;
                    }
                }
            }

            for (int i = 0; i < building.GetLength(0); i++)
            {
                for (int j = 0; j < building.GetLength(1); j++)
                {
                    Console.Write(building[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
