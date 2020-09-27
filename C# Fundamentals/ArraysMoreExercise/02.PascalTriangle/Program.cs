using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] triangle = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                triangle[row, 0] = 1;
                triangle[row, row] = 1;
            }

            for (int row = 2; row < size; row++)
            {
                for (int col = 1; col < row; col++)
                {
                    triangle[row, col] = triangle[row - 1, col - 1] + triangle[row - 1, col];
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (triangle[row, col] == 0)
                    {
                        continue;
                    }

                    Console.Write(triangle[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
