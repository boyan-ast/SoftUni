using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = new int[numbers.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = numbers[j];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split();

                string action = commandArgs[0];

                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int num = int.Parse(commandArgs[3]);

                if ((row < 0 || row >= rows) ||
                    (col < 0 || col >= matrix[row].Length))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (action == "Add")
                {
                    matrix[row][col] += num;
                }
                else if (action == "Subtract")
                {
                    matrix[row][col] -= num;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
