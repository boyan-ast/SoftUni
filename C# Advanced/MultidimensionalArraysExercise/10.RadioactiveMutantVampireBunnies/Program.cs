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

            int row = -1;
            int col = -1;

            for (int i = 0; i < rows; i++)
            {
                string rowData = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowData[j];

                    if (matrix[i, j] == 'P')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            Position position = new Position(row, col);

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                char direction = directions[i];

                if (direction == 'L')
                {
                    MoveLeft(matrix, position);
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
                else if (direction == 'R')
                {
                    MoveRight(matrix, position);
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
                else if (direction == 'U')
                {
                    MoveUp(matrix, position);
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
                else if (direction == 'D')
                {
                    MoveDown(matrix, position);
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
        }

        private static void MoveDown(char[,] matrix, Position position)
        {
            int row = position.Row;
            int col = position.Col;
            matrix[row, col] = '.';

            if (!ValidatePosition(row + 1, col, matrix.GetLength(0), matrix.GetLength(1)))
            {
                position.HasWon = true;
                return;
            }
            else if (matrix[row + 1, col] == 'B')
            {
                position.Row++;
                position.HasLost = true;
                return;
            }
            else
            {
                position.Row++;
                matrix[row + 1, col] = 'P';
            }
        }

        private static void MoveUp(char[,] matrix, Position position)
        {
            int row = position.Row;
            int col = position.Col;
            matrix[row, col] = '.';

            if (!ValidatePosition(row - 1, col, matrix.GetLength(0), matrix.GetLength(1)))
            {
                position.HasWon = true;
                return;
            }
            else if (matrix[row - 1, col] == 'B')
            {
                position.Row--;
                position.HasLost = true;
                return;
            }
            else
            {
                position.Row--;
                matrix[row - 1, col] = 'P';
            }
        }

        private static void MoveRight(char[,] matrix, Position position)
        {
            int row = position.Row;
            int col = position.Col;
            matrix[row, col] = '.';

            if (!ValidatePosition(row, col + 1, matrix.GetLength(0), matrix.GetLength(1)))
            {
                position.HasWon = true;
                return;
            }
            else if (matrix[row, col + 1] == 'B')
            {
                position.Col++;
                position.HasLost = true;
                return;
            }
            else
            {
                position.Col++;
                matrix[row, col + 1] = 'P';
            }
        }

        private static void MoveLeft(char[,] matrix, Position position)
        {
            int row = position.Row;
            int col = position.Col;
            matrix[row, col] = '.';

            if (!ValidatePosition(row, col - 1, matrix.GetLength(0), matrix.GetLength(1)))
            {
                position.HasWon = true;
                return;
            }
            else if (matrix[row, col - 1] == 'B')
            {
                position.Col--;
                position.HasLost = true;
                return;
            }
            else
            {
                position.Col--;
                matrix[row, col - 1] = 'P';
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
                        if (ValidatePosition(row, col - 1, n, m) && matrix[row, col - 1] != 'B')
                        {
                            if (matrix[row, col - 1] == 'P' && !position.HasWon)
                            {
                                position.HasLost = true;
                            }

                            matrix[row, col - 1] = 'b';
                        }

                        if (ValidatePosition(row - 1, col, n, m) && matrix[row - 1, col] != 'B')
                        {
                            if (matrix[row - 1, col] == 'P' && !position.HasWon)
                            {
                                position.HasLost = true;
                            }

                            matrix[row - 1, col] = 'b';
                        }

                        if (ValidatePosition(row, col + 1, n, m) && matrix[row, col + 1] != 'B')
                        {
                            if (matrix[row, col + 1] == 'P' && !position.HasWon)
                            {
                                position.HasLost = true;
                            }

                            matrix[row, col + 1] = 'b';
                        }

                        if (ValidatePosition(row + 1, col, n, m) && matrix[row + 1, col] != 'B')
                        {
                            if (matrix[row + 1, col] == 'P' && !position.HasWon)
                            {
                                position.HasLost = true;
                            }

                            matrix[row + 1, col] = 'b';
                        }
                    }
                }
            }

            UpdateBunniesToUpper(matrix);

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
