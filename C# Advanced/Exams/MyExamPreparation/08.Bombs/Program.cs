using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(n);

            string[] bombsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[][] bombs = new int[bombsData.Length][];

            for (int i = 0; i < bombsData.Length; i++)
            {
                int[] bombInfo = bombsData[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] bomb = new int[] { bombInfo[0], bombInfo[1] };

                bombs[i] = bomb;
            }

            foreach (int[] bomb in bombs)
            {
                int row = bomb[0];
                int col = bomb[1];

                if (matrix[row, col] > 0)
                {
                    Explode(matrix, row, col);
                }
            }

            int count = 0;
            int sum = 0;

            foreach (int number in matrix)
            {
                if (number > 0)
                {
                    count++;
                    sum += number;
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }

        private static void Explode(int[,] matrix, int row, int col)
        {
            int value = matrix[row, col];
            matrix[row, col] = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        if (IsValidPosition(matrix.GetLength(0), row + i, col + j)
                            && matrix[row + i, col + j] > 0)
                        {
                            matrix[row + i, col + j] -= value;
                        }
                    }
                }
            }
        }

        static bool IsValidPosition(int n, int row, int col)
        {
            if (row < 0 || col < 0 || row >= n || col >= n)
            {
                return false;
            }

            return true;
        }

        public static int[,] ReadMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
