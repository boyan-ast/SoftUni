using System;
using System.Linq;

namespace _06.JaggedArrayManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new double[rowData.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row+1].Length)
                {
                    matrix[row] = matrix[row].Select(x => { x = x * 2; return x; }).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => { x = x * 2; return x; }).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => { x = x / 2; return x; }).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => { x = x / 2; return x; }).ToArray();
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (row < 0 || row >= n || col >= matrix[row].Length || col < 0)
                {
                    continue;
                }

                if (action == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (action == "Subtract")
                {
                    matrix[row][col] -= value;
                }

            }

            // Printing the matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
