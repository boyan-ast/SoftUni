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

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine().Replace(" ", "");

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == '<')
                    {
                        firstCount++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondCount++;
                    }
                }
            }

            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int row = positions[i][0];
                int col = positions[i][1];

                if (!IsValidPosition(row, col, n))
                {
                    continue;
                }

                if (i % 2 == 0)
                {
                    if (matrix[row, col] == '#')
                    {
                        matrix[row, col] = 'X';

                        for (int j = -1; j <= 1; j++)
                        {
                            for (int k = -1; k <= 1; k++)
                            {
                                if (IsValidPosition(row + j, col + k, n))
                                {
                                    if (matrix[row + j, col + k] == '<')
                                    {
                                        matrix[row + j, col + k] = 'X';
                                        firstCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                    else if (matrix[row + j, col + k] == '>')
                                    {
                                        matrix[row + j, col + k] = 'X';
                                        secondCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                }
                            }
                        }
                    }
                    else if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        secondCount--;
                        totalCountShipsDestroyed++;
                    }
                    else if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        firstCount--;
                        totalCountShipsDestroyed++;
                    }

                    if (firstCount == 0)
                    {
                        break;
                    }
                    else if (secondCount == 0)
                    {
                        break;
                    }
                }
                else
                {
                    if (matrix[row, col] == '#')
                    {
                        matrix[row, col] = 'X';

                        for (int j = -1; j <= 1; j++)
                        {
                            for (int k = -1; k <= 1; k++)
                            {
                                if (IsValidPosition(row + j, col + k, n))
                                {
                                    if (matrix[row + j, col + k] == '<')
                                    {
                                        matrix[row + j, col + k] = 'X';
                                        firstCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                    else if (matrix[row + j, col + k] == '>')
                                    {
                                        matrix[row + j, col + k] = 'X';
                                        secondCount--;
                                        totalCountShipsDestroyed++;
                                    }
                                }
                            }
                        }
                    }
                    else if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        totalCountShipsDestroyed++;
                        firstCount--;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        totalCountShipsDestroyed++;
                        secondCount--;
                    }

                    if (firstCount == 0)
                    {
                        break;
                    }

                    if (secondCount == 0)
                    {
                        break;
                    }
                }

            }

            if (secondCount == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (firstCount == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstCount} ships left. Player Two has {secondCount} ships left.");
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
