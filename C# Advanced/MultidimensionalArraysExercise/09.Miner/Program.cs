using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[n, n];
            int coals = 0;
            int row = -1;
            int col = -1;

            for (int i = 0; i < n; i++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = rowData[j];

                    if (field[i, j] == 'c')
                    {
                        coals++;
                    }
                    else if (field[i, j] == 's')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            int collectedCoals = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "right" && (col + 1 < n))
                {
                    field[row, col] = '*';

                    col++;

                    if (field[row, col] == 'c')
                    {
                        collectedCoals++;
                        coals--;

                        if (coals == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({row}, {col})");
                            return;
                        }
                    }
                    else if (field[row, col] == 'e')
                    {
                        Console.WriteLine($"Game over! ({row}, {col})");
                        return;
                    }

                    field[row, col] = 's';
                }
                else if (command == "left" && (col - 1 >= 0))
                {
                    field[row, col] = '*';
                    col--;

                    if (field[row, col] == 'c')
                    {
                        collectedCoals++;
                        coals--;

                        if (coals == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({row}, {col})");
                            return;
                        }
                    }
                    else if (field[row, col] == 'e')
                    {
                        Console.WriteLine($"Game over! ({row}, {col})");
                        return;
                    }

                    field[row, col] = 's';
                }
                else if (command == "down" && (row + 1 < n))
                {
                    field[row, col] = '*';
                    row++;

                    if (field[row, col] == 'c')
                    {
                        collectedCoals++;
                        coals--;

                        if (coals == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({row}, {col})");
                            return;
                        }
                    }
                    else if (field[row, col] == 'e')
                    {
                        Console.WriteLine($"Game over! ({row}, {col})");
                        return;
                    }

                    field[row, col] = 's';
                }
                else if (command == "up" && (row - 1 >= 0))
                {
                    field[row, col] = '*';
                    row--;

                    if (field[row, col] == 'c')
                    {
                        collectedCoals++;
                        coals--;

                        if (coals == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({row}, {col})");
                            return;
                        }
                    }
                    else if (field[row, col] == 'e')
                    {
                        Console.WriteLine($"Game over! ({row}, {col})");
                        return;
                    }
                    field[row, col] = 's';
                }

                //Console.WriteLine("------------------------------");
                //PrintMatrix(field);
            }

            Console.WriteLine($"{coals} coals left. ({row}, {col})");

        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
