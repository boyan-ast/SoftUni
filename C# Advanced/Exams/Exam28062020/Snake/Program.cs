using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            bool isFed = false;
            int foods = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        if (firstBurrowRow == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                int nextRow = snakeRow;
                int nextCol = snakeCol;

                matrix[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    nextRow--;
                }
                else if (command == "down")
                {
                    nextRow++;
                }
                else if (command == "left")
                {
                    nextCol--;
                }
                else if (command == "right")
                {
                    nextCol++;
                }

                if (IsValidPosition(nextRow, nextCol, n))
                {
                    snakeRow = nextRow;
                    snakeCol = nextCol;

                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foods++;

                        if (foods == 10)
                        {
                            isFed = true;
                        }
                    }
                    else if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';

                        if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                        {
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                        }
                    }

                    matrix[snakeRow, snakeCol] = 'S';

                    if (isFed)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (isFed)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {foods}");

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
