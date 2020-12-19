using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];

            int col = 1;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new long[col];

                matrix[i][0] = 1;
                matrix[i][matrix[i].Length - 1] = 1;

                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j] + matrix[i - 1][j - 1];
                }

                col++;
            }

            PrintTriangle(matrix);
        }

        private static void PrintTriangle(long[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
