using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            int flowers = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';

                int nextRox = beeRow;
                int nextCol = beeCol;

                if (command == "up")
                {
                    nextRox--;
                }
                else if (command == "down")
                {
                    nextRox++;
                }
                else if (command == "left")
                {
                    nextCol--;
                }
                else if (command == "right")
                {
                    nextCol++;
                }

                if (IsValidPosition(nextRox, nextCol, n))
                {
                    beeRow = nextRox;
                    beeCol = nextCol;

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';

                        nextRox = beeRow;
                        nextCol = beeCol;

                        if (command == "up")
                        {
                            nextRox--;
                        }
                        else if (command == "down")
                        {
                            nextRox++;
                        }
                        else if (command == "left")
                        {
                            nextCol--;
                        }
                        else if (command == "right")
                        {
                            nextCol++;
                        }

                        if (IsValidPosition(nextRox, nextCol, n))
                        {
                            beeRow = nextRox;
                            beeCol = nextCol;

                            if (matrix[beeRow, beeCol] == 'f')
                            {
                                flowers++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                    }

                    matrix[beeRow, beeCol] = 'B';
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
            }

            Console.WriteLine(flowers >= 5 ?
                $"Great job, the bee managed to pollinate {flowers} flowers!" :
                $"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");

            PrintMatrix(matrix);
        }
        static bool IsValidPosition(int row, int col, int n)
        {
            if (row < 0 || row >= n || col < 0 || col >= n)
            {
                return false;
            }

            return true;
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
