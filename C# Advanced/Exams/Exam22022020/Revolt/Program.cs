using System;

namespace Revolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool isExtraMove = false;
            bool hasWon = false;
            string command = string.Empty;

            for (int i = 0; i < commands; i++)
            {
                if (!isExtraMove)
                {
                    command = Console.ReadLine();
                    matrix[playerRow, playerCol] = '-';
                }
                else
                {
                    isExtraMove = false;
                }               

                if (command == "up")
                {
                    playerRow--;

                    if (!IsValidPosition(playerRow, playerCol, n))
                    {
                        playerRow = n - 1;
                    }
                }
                else if (command == "down")
                {
                    playerRow++;

                    if (!IsValidPosition(playerRow, playerCol, n))
                    {
                        playerRow = 0;
                    }
                }
                else if (command == "left")
                {
                    playerCol--;
                    if (!IsValidPosition(playerRow, playerCol, n))
                    {
                        playerCol = n - 1;
                    }
                }
                else if (command == "right")
                {
                    playerCol++;
                    if (!IsValidPosition(playerRow, playerCol, n))
                    {
                        playerCol = 0;
                    }
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    isExtraMove = true;
                    i--;
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    isExtraMove = true;
                    i--;

                    if (command == "down")
                    {
                        command = "up";
                    }
                    else if (command == "up")
                    {
                        command = "down";
                    }
                    else if (command == "left")
                    {
                        command = "right";
                    }
                    else if (command == "right")
                    {
                        command = "left";
                    }
                }
                else if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    hasWon = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'f';
                }
               

                if (hasWon)
                {
                    break;
                }

            }

            Console.WriteLine(hasWon ? "Player won!" : "Player lost!");
            PrintMatrix(matrix);

        }

        static void PrintMatrix(char[,] matrix)
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
