using System;
using System.Linq;

namespace _04.MatrxiShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColsData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = ReadMatrix(rowsAndColsData[0], rowsAndColsData[1]);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] != "swap" || input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int firstRow = int.Parse(input[1]);
                int firstCol = int.Parse(input[2]);
                int secondRow = int.Parse(input[3]);
                int secondCol = int.Parse(input[4]);

                if (firstRow < 0 || firstRow >= matrix.GetLength(0) || firstCol < 0 || firstCol >= matrix.GetLength(1) || 
                    secondRow < 0 || secondCol < 0 || secondRow >= matrix.GetLength(0) || secondCol >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string temp = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = temp;

                PrintMatrix(matrix);
            }

        }

        private static void PrintMatrix(string[,] matrix)
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

        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);                    

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
