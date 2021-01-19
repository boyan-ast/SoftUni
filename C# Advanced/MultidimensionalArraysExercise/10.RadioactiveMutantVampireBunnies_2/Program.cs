using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            Position position = new Position(playerRow, playerCol);

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                char direction = directions[i];

                if (direction == 'L')
                {
                    Move(matrix, position, 0, -1);
                }
                else if (direction == 'R')
                {
                    Move(matrix, position, 0, 1);
                }
                else if (direction == 'U')
                {
                    Move(matrix, position, -1);
                }
                else if (direction == 'D')
                {
                    Move(matrix, position, 1);
                }

                SpreadBunnies(matrix, position);

                if (position.HasWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {position}");
                    return;
                }
                else if (position.HasLost)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {position}");
                    return;
                }
            }
        }

        private static void Move(char[,] matrix, Position position, int rowMove = 0, int colMove = 0)
        {
            matrix[position.Row, position.Col] = '.';

            if (!ValidatePosition(position.Row + rowMove, position.Col + colMove, matrix.GetLength(0), matrix.GetLength(1)))
            {
                position.HasWon = true;
                return;
            }
            else if (matrix[position.Row + rowMove, position.Col + colMove] == 'B')
            {
                position.Row += rowMove;
                position.Col += colMove;
                position.HasLost = true;
                return;
            }
            else
            {
                position.Row += rowMove;
                position.Col += colMove;
                matrix[position.Row, position.Col] = 'P';
            }
        }

        private static void SpreadBunnies(char[,] matrix, Position position)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        SpreadBunny(matrix, row, col - 1, position);
                        SpreadBunny(matrix, row - 1, col, position);
                        SpreadBunny(matrix, row, col + 1, position);
                        SpreadBunny(matrix, row + 1, col, position);                        
                    }
                }
            }

            UpdateBunniesToUpper(matrix);
        }

        private static void SpreadBunny(char[,] matrix, int row, int col, Position position)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (ValidatePosition(row, col, n, m) && matrix[row, col] != 'B')
            {
                if (matrix[row, col] == 'P' && !position.HasWon)
                {
                    position.HasLost = true;
                }

                matrix[row, col] = 'b';
            }
        }

        private static void UpdateBunniesToUpper(char[,] matrix)
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

        static bool ValidatePosition(int row, int col, int n, int m)
        {
            if (row < 0 || row >= n || col < 0 || col >= m)
            {
                return false;
            }

            return true;
        }

        static char[,] ReadMatrix(int n, int m)
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

    class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool HasWon { get; set; }
        public bool HasLost { get; set; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
            HasWon = false;
            HasLost = false;
        }

        public override string ToString()
        {
            return $"{Row} {Col}";
        }
    }
}
