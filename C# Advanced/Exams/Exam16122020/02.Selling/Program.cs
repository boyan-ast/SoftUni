using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(n);
            bool isInside = true;
            bool isSuccessful = false;

            int money = 0;

            int row = -1;
            int col = -1;
            int firstPillarRow = -1;
            int firstPillarCol = -1;
            int secondPillarRow = -1;
            int secondPillarCol = -1;

            //Find seller and pillars positions

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                    else if (matrix[i, j] == 'O')
                    {
                        if (firstPillarRow == -1)
                        {
                            firstPillarRow = i;
                            firstPillarCol = j;
                        }
                        else
                        {
                            secondPillarRow = i;
                            secondPillarCol = j;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                int newRow = row;
                int newCol = col;

                matrix[row, col] = '-';
                
                if (command == "up")
                {
                    newRow = row - 1;
                }
                else if (command == "down")
                {
                    newRow = row + 1;
                }
                else if (command == "left")
                {
                    newCol = col - 1;
                }
                else if (command == "right")
                {
                    newCol = col + 1;
                }                

                if (CheckPosition(newRow, newCol, n))
                {
                    if (CheckForClient(newRow, newCol, matrix))
                    {
                        money += int.Parse(matrix[newRow, newCol].ToString());
                    }
                    else if (matrix[newRow, newCol] == 'O')
                    {
                        matrix[newRow, newCol] = '-';

                        if (newRow == firstPillarRow && newCol == firstPillarCol)
                        {
                            newRow = secondPillarRow;
                            newCol = secondPillarCol;
                        }
                        else
                        {
                            newRow = firstPillarRow;
                            newCol = firstPillarCol;
                        }
                    }
                    
                    row = newRow;
                    col = newCol;

                    matrix[row, col] = 'S';

                    if (money >= 50)
                    {
                        isSuccessful = true;
                        break;
                    }
                }
                else
                {
                    isInside = false;
                    break;
                }
            }

            if (!isInside)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else if (isSuccessful)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            PrintMatrix(matrix);
        }

        private static bool CheckForClient(int row, int col, char[,] matrix)
        {
            return char.IsDigit(matrix[row, col]);
        }

        static bool CheckPosition(int row, int col, int n)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
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

                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
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
    }
}
