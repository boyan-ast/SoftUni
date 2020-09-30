using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            PrintTriange(size);
        }

        private static void PrintTriange(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintLine(1, row);
                Console.WriteLine();
            }

            for (int row = n - 1; row >= 1; row--)
            {
                PrintLine(1, row);
                Console.WriteLine();
            }
        }

        static void PrintLine(int start, int end)
        {
            for (int col = start; col <= end; col++)
            {
                Console.Write($"{col} ");
            }
        }
    }
}
