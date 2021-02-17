using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // Read Matrix
            char[,] inputMatrix = ReadMatrix(n);

            // Transform char[,] into int[,]
            int[,] matrix = TransformMatrix(inputMatrix);

            int count = 0;

            // Start removing the biggest number in matrix, until all elements are <= 0

            while (true)
            {
                int max = 0;
                int maxRow = -1;
                int maxCol = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] > max)
                        {
                            max = matrix[row, col];
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (maxRow == -1)
                {
                    break;
                }
                else
                {
                    count++;
                    matrix[maxRow, maxCol] = 0;

                    if (IsValidPosition(n, n, maxRow - 2, maxCol + 1))
                    {
                        matrix[maxRow - 2, maxCol + 1]--;
                    }
                    if (IsValidPosition(n, n, maxRow - 2, maxCol - 1))
                    {
                        matrix[maxRow - 2, maxCol - 1]--;
                    }
                    if (IsValidPosition(n, n, maxRow - 1, maxCol + 2))
                    {
                        matrix[maxRow - 1, maxCol + 2]--;
                    }
                    if (IsValidPosition(n, n, maxRow - 1, maxCol - 2))
                    {
                        matrix[maxRow - 1, maxCol - 2]--;
                    }
                    if (IsValidPosition(n, n, maxRow + 1, maxCol - 2))
                    {
                        matrix[maxRow + 1, maxCol - 2]--;
                    }
                    if (IsValidPosition(n, n, maxRow + 1, maxCol + 2))
                    {
                        matrix[maxRow + 1, maxCol + 2]--;
                    }
                    if (IsValidPosition(n, n, maxRow + 2, maxCol - 1))
                    {
                        matrix[maxRow + 2, maxCol - 1]--;
                    }
                    if (IsValidPosition(n, n, maxRow + 2, maxCol + 1))
                    {
                        matrix[maxRow + 2, maxCol + 1]--;
                    }
                }
            }

            Console.WriteLine(count);
        }


        private static int[,] TransformMatrix(char[,] inputMatrix)
        {
            int n = inputMatrix.GetLength(0);
            int m = inputMatrix.GetLength(1);

            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (inputMatrix[row, col] == 'K')
                    {
                        if (IsValidPosition(n, m, row - 2, col + 1) && inputMatrix[row - 2, col + 1] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row - 2, col - 1) && inputMatrix[row - 2, col - 1] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row - 1, col + 2) && inputMatrix[row - 1, col + 2] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row - 1, col - 2) && inputMatrix[row - 1, col - 2] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row + 1, col - 2) && inputMatrix[row + 1, col - 2] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row + 1, col + 2) && inputMatrix[row + 1, col + 2] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row + 2, col - 1) && inputMatrix[row + 2, col - 1] == 'K')
                        {
                            matrix[row, col]++;
                        }
                        if (IsValidPosition(n, m, row + 2, col + 1) && inputMatrix[row + 2, col + 1] == 'K')
                        {
                            matrix[row, col]++;
                        }
                    }

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

        private static bool IsValidPosition(int n, int m, int row, int col)
        {
            if (row < 0 || row >= n || col < 0 || col >= m)
            {
                return false;
            }

            return true;
        }

        private static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
