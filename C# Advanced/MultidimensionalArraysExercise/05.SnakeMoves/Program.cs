using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[rowsAndColsData[0], rowsAndColsData[1]];

            Queue<char> snake = new Queue<char>(Console.ReadLine());

            int row = 0;
            int col = 0;

            string direction = "right";

            while (true)
            {
                char symbol = snake.Dequeue();
                matrix[row, col] = symbol;
                snake.Enqueue(symbol);                

                if (direction == "right")
                {
                    col++;

                    if (col == matrix.GetLength(1))
                    {
                        col--;
                        row++;

                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    col--;

                    if (col < 0)
                    {
                        col++;
                        row++;

                        direction = "right";
                    }
                }

                if (row == matrix.GetLength(0))
                {
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
