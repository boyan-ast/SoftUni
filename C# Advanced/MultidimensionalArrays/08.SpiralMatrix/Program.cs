using System;

namespace _08.SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            string direction = "right";
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * n; i++)
            {
                matrix[row, col] = i + 1;

                if (direction == "right")
                {
                    col++;

                    if (col == n || matrix[row, col] != 0)
                    {
                        col--;

                        direction = "down";
                    }
                }

                if (direction == "down")
                {
                    row++;

                    if (row == n || matrix[row, col] != 0)
                    {
                        row--;

                        direction = "left";
                    }
                }

                if (direction == "left")
                {
                    col--;

                    if (col < 0 || matrix[row, col] != 0)
                    {
                        col++;

                        direction = "up";
                    }
                }

                if (direction == "up")
                {
                    row--;

                    if (row == 0 || matrix[row, col] != 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 10)
                    {
                        Console.Write($" {matrix[i, j]} ");
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
