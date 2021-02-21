using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            int[][] positions = new int[commands.Length][];

            for (int i = 0; i < commands.Length; i++)
            {
                int[] pair = commands[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                positions[i] = new int[2];
                positions[i][0] = pair[0];
                positions[i][1] = pair[1];
            }

            int firstCount = 0;
            int secondCount = 0;
            int totalCountShipsDestroyed = 0;
            bool hasWinner = false;
            string winner = string.Empty;

            string[,] matrix = new string[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == "<")
                    {
                        firstCount++;
                    }
                    else if (matrix[row, col] == ">")
                    {
                        secondCount++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                int row = positions[i][0];
                int col = positions[i][1];

                if (!IsValidPosition(row, col, n)
                    || matrix[row, col] == "*"
                    || matrix[row, col] == "X")
                {
                    continue;
                }

                if (i % 2 == 0)
                {
                    if (matrix[row, col] == "#")
                    {
                        matrix[row, col] = "X";

                        for (int j = -1; j <= 1; j++)
                        {
                            for (int k = -1; k <= 1; k++)
                            {
                                if (IsValidPosition(row + j, col + k, n))
                                {
                                    if (matrix[row + j, col + k] == "<")
                                    {
                                        matrix[row + j, col + k] = "X";
                                        firstCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                    else if (matrix[row + j, col + k] == ">")
                                    {
                                        matrix[row + j, col + k] = "X";
                                        secondCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                }
                            }
                        }
                    }
                    else if (matrix[row, col] == ">")
                    {
                        matrix[row, col] = "X";
                        secondCount--;
                        totalCountShipsDestroyed++;
                    }

                    if (secondCount == 0)
                    {
                        hasWinner = true;
                        winner = "One";
                        break;
                    }
                }
                else
                {
                    if (matrix[row, col] == "#")
                    {
                        matrix[row, col] = "X";

                        for (int j = -1; j <= 1; j++)
                        {
                            for (int k = -1; k <= 1; k++)
                            {
                                if (IsValidPosition(row + j, col + k, n))
                                {
                                    if (matrix[row + j, col + k] == "<")
                                    {
                                        matrix[row + j, col + k] = "X";
                                        firstCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                    else if (matrix[row + j, col + k] == ">")
                                    {
                                        matrix[row + j, col + k] = "X";
                                        secondCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                }
                            }
                        }
                    }
                    else if (matrix[row, col] == "<")
                    {
                        matrix[row, col] = "X";
                        firstCount--;
                        totalCountShipsDestroyed++;
                    }

                    if (firstCount == 0)
                    {
                        hasWinner = true;
                        winner = "Two";
                        break;
                    }
                }
            }

            if (hasWinner)
            {
                Console.WriteLine($"Player {winner} has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstCount} ships left. Player Two has {secondCount} ships left.");
            }


        }

        static void PrintMatrix(string[,] matrix)
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
        static bool IsValidPosition(int row, int col, int n)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }

            return true;
        }
    }
}
