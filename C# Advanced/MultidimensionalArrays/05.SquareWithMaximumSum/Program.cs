using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < numbers.Length; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRow = -1;
            int maxSumCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + 
                        matrix[row + 1, col] + 
                        matrix[row, col + 1] + 
                        matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
            Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");

            Console.WriteLine(maxSum);
        }
    }
}
