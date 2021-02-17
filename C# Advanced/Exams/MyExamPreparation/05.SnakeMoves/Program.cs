using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = sizes[0];
            int m = sizes[1];

            Queue<char> snake = new Queue<char>(Console.ReadLine());

            char[,] matrix = new char[n, m];

            int row = 0;
            int col = 0;

            string direction = "right";

            while (row < n)
            {
                char symbol = snake.Dequeue();
                matrix[row, col] = symbol;

                snake.Enqueue(symbol);

                if (direction == "right")
                {
                    col++;
                    if (col == m)
                    {
                        col--;
                        row++;
                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    col--;
                    if (col == -1)
                    {
                        col = 0;
                        row++;
                        direction = "right";
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
