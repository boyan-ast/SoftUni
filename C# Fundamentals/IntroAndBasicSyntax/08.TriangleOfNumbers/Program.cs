﻿using System;

namespace _08.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write($"{row} ");
                }
                Console.WriteLine();
            }
        }
    }
}
