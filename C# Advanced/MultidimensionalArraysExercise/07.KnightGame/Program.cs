using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] initialMatrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine().Trim();

                for (int col = 0; col < rowData.Length; col++)
                {
                    initialMatrix[row, col] = rowData[col];
                }
            }

            //PrintMatrix(initialMatrix);
            //Console.WriteLine("-------------------------");

            //Transform the char[,] into int[,]

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (initialMatrix[row,col] == 'K')
                    {
                        int count = 0;

                        if (CheckForValidIndexes(row - 2, col - 1, n) && initialMatrix[row-2, col-1] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row - 2, col + 1, n) && initialMatrix[row - 2, col + 1] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row - 1, col - 2, n) && initialMatrix[row - 1, col - 2] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row - 1, col + 2, n) && initialMatrix[row - 1, col + 2] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row + 1, col - 2, n) && initialMatrix[row +1, col - 2] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row + 1, col + 2, n) && initialMatrix[row + 1, col + 2] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row + 2, col - 1, n) && initialMatrix[row + 2, col - 1] == 'K')
                        {
                            count++;
                        }

                        if (CheckForValidIndexes(row + 2, col + 1, n) && initialMatrix[row + 2, col + 1] == 'K')
                        {
                            count++;
                        }

                        matrix[row, col] = count;
                    }
                }
            }

            //PrintMatrix(matrix);

            int knightsCount = 0;

            while (MatrixSum(matrix) > 0)
            {
                int maxElement = 0;
                int maxElementRow = -1;
                int maxElementCol = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row,col] > maxElement)
                        {
                            maxElement = matrix[row, col];
                            maxElementRow = row;
                            maxElementCol = col;
                        }
                    }
                }

                matrix[maxElementRow, maxElementCol] = 0;
                knightsCount++;

                if (CheckForValidIndexes(maxElementRow - 2, maxElementCol - 1, n) && matrix[maxElementRow - 2, maxElementCol - 1] > 0)
                {
                    matrix[maxElementRow - 2, maxElementCol - 1]--;
                }

                if (CheckForValidIndexes(maxElementRow - 2, maxElementCol + 1, n) && matrix[maxElementRow - 2, maxElementCol + 1] > 0)
                {
                    matrix[maxElementRow - 2, maxElementCol + 1]--;
                }

                if (CheckForValidIndexes(maxElementRow - 1, maxElementCol - 2, n) && matrix[maxElementRow - 1, maxElementCol - 2] > 0)
                {
                    matrix[maxElementRow - 1, maxElementCol - 2]--;
                }

                if (CheckForValidIndexes(maxElementRow - 1, maxElementCol + 2, n) && matrix[maxElementRow - 1, maxElementCol + 2] > 0)
                {
                    matrix[maxElementRow - 1, maxElementCol + 2]--;
                }

                if (CheckForValidIndexes(maxElementRow + 1, maxElementCol - 2, n) && matrix[maxElementRow + 1, maxElementCol - 2] > 0)
                {
                    matrix[maxElementRow + 1, maxElementCol - 2]--;
                }

                if (CheckForValidIndexes(maxElementRow + 1, maxElementCol + 2, n) && matrix[maxElementRow + 1, maxElementCol + 2] > 0)
                {
                    matrix[maxElementRow + 1, maxElementCol + 2]--;
                }

                if (CheckForValidIndexes(maxElementRow + 2, maxElementCol - 1, n) && matrix[maxElementRow + 2, maxElementCol - 1] > 0)
                {
                    matrix[maxElementRow + 2, maxElementCol - 1]--;
                }

                if (CheckForValidIndexes(maxElementRow + 2, maxElementCol + 1, n) && matrix[maxElementRow + 2, maxElementCol + 1] > 0)
                {
                    matrix[maxElementRow + 2, maxElementCol + 1]--;
                }

                //Console.WriteLine("----------------------");
                //PrintMatrix(matrix);
            }

            Console.WriteLine(knightsCount);
        }

        static bool CheckForValidIndexes(int row, int col, int n)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }

            return true;
        }

        static int MatrixSum(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
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
