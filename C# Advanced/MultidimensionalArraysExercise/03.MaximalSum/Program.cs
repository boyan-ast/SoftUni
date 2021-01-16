using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = ReadMatrix(input[0], input[1]);

            int n = 3;
            int maxRow = -1;
            int maxCol = -1;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - n + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - n + 1; col++)
                {
                    int startRow = row;
                    int startCol = col;
                    int sum = 0;

                    for (int currentRow = row; currentRow < row + n; currentRow++)
                    {
                        for (int currentCol = col; currentCol < col + n; currentCol++)
                        {
                            sum += matrix[currentRow, currentCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxRow = startRow;
                        maxCol = startCol;
                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            PrintMatrix(matrix, n, n, maxRow, maxCol);

        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix, int rows, int cols, int startRow, int startCol)
        {
            for (int row = startRow; row < startRow + rows; row++)
            {
                for (int col = startCol; col < startCol + cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
