using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

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

            string[] bombsDataAsString = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[,] bombsData = new int[bombsDataAsString.Length, 2];
            int count = 0;

            foreach (string bomb in bombsDataAsString)
            {
                int row = int.Parse(bomb.Split(",", StringSplitOptions.RemoveEmptyEntries)[0]);
                int col = int.Parse(bomb.Split(",", StringSplitOptions.RemoveEmptyEntries)[1]);
                bombsData[count, 0] = row;
                bombsData[count, 1] = col;
                count++;
            }

            for (int i = 0; i < bombsData.GetLength(0); i++)
            {
                int row = bombsData[i, 0];
                int col = bombsData[i, 1];

                int power = matrix[row, col];

                if (power <= 0)
                {
                    continue;
                }

                matrix[row, col] = 0;

                if (IsValidCell(row - 1, col - 1, n) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= power;
                }
                if (IsValidCell(row - 1, col, n) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= power;
                }
                if (IsValidCell(row - 1, col + 1, n) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= power;
                }
                if (IsValidCell(row, col - 1, n) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= power;
                }
                if (IsValidCell(row, col + 1, n) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= power;
                }
                if (IsValidCell(row + 1, col - 1, n) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= power;
                }
                if (IsValidCell(row + 1, col, n) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= power;
                }
                if (IsValidCell(row + 1, col + 1, n) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= power;
                }
            }

            Console.WriteLine($"Alive cells: {CalculateCountAndSum(matrix).Item1}");
            Console.WriteLine($"Sum: {CalculateCountAndSum(matrix).Item2}");
            PrintMatrix(matrix);
        }

        private static Tuple<int, int> CalculateCountAndSum(int[,] matrix)
        {
            int count = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            return Tuple.Create(count, sum);
        }

        static bool IsValidCell(int row, int col, int n)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }

            return true;
        }
        static void PrintMatrix(int[,] matrix)
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
