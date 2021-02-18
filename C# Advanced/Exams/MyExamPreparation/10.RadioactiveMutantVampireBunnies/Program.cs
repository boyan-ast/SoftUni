using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static bool isWinner = false;
        static bool isDead = false;

        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = sizes[0];
            int m = sizes[1];

            char[,] matrix = ReadMatrix(n, m);

            int row = -1;
            int col = -1;

            // Find the player

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            string moves = Console.ReadLine();

            for (int i = 0; i < moves.Length; i++)
            {
                char command = moves[i];

                // Move Player

                int nextRow = row;
                int nextCol = col;

                matrix[row, col] = '.';

                if (command == 'U')
                {
                    nextRow--;
                }
                else if (command == 'D')
                {
                    nextRow++;
                }
                else if (command == 'L')
                {
                    nextCol--;
                }
                else if (command == 'R')
                {
                    nextCol++;
                }

                if (!IsValidPosition(n, m, nextRow, nextCol))
                {
                    isWinner = true;
                }
                else if (matrix[nextRow, nextCol] == 'B')
                {
                    isDead = true;
                }

                if (isWinner)
                {
                    SpreadBunnies(matrix);
                    break;
                }

                row = nextRow;
                col = nextCol;

                if (!isDead)
                {
                    matrix[row, col] = 'P';
                }

                SpreadBunnies(matrix);

                if (isDead)
                {
                    break;
                }
            }

            PrintMatrix(matrix);

            Console.Write(isWinner ? "won: " : "dead: ");
            Console.WriteLine($"{row} {col}");

        }

        private static void SpreadBunnies(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (Math.Abs(i) != Math.Abs(j)
                                    && IsValidPosition(n, m, row + i, col + j)
                                    && matrix[row + i, col + j] != 'B')
                                {
                                    if (matrix[row + i, col + j] == 'P')
                                    {
                                        isDead = true;
                                    }

                                    matrix[row + i, col + j] = 'b';
                                }
                            }
                        }
                    }
                }
            }

            TheNewBunniesGrow(matrix);
        }

        private static void TheNewBunniesGrow(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }

        static bool IsValidPosition(int n, int m, int row, int col)
        {
            if (row < 0 || col < 0 || row >= n || col >= m)
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix(int n, int m)
        {
            char[,] matrix = new char[n, m];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
