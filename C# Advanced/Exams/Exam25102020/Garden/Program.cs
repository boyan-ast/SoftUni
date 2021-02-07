using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = sizes[0];
            int m = sizes[1];

            int[,] matrix = ReadMatrix(n, m);
            List<int[]> flowers = new List<int[]>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] position = command
                .Split()
                .Select(int.Parse)
                .ToArray();

                int row = position[0];
                int col = position[1];

                if (IsValidPosition(n, m, row, col))
                {
                    matrix[row, col] = 1;
                    flowers.Add(new int[] { row, col });
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (int[] flower in flowers)
            {
                int flowerRow = flower[0];
                int flowerCol = flower[1];

                FlowersBloom(matrix, flowerRow, flowerCol);
            }

            PrintMatrix(matrix);
        }

        private static void FlowersBloom(int[,] matrix, int flowerRow, int flowerCol)
        {
            for (int col = 0; col < flowerCol; col++)
            {
                matrix[flowerRow, col]++;
            }

            for (int col = flowerCol + 1; col < matrix.GetLength(1); col++)
            {
                matrix[flowerRow, col]++;
            }

            for (int row = 0; row < flowerRow; row++)
            {
                matrix[row, flowerCol]++;
            }

            for (int row = flowerRow + 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, flowerCol]++;
            }
        }

        static bool IsValidPosition(int n, int m, int row, int col)
        {
            if (row < 0 || row >= n || col < 0 || col >= m)
            {
                return false;
            }

            return true;
        }

        static int[,] ReadMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
