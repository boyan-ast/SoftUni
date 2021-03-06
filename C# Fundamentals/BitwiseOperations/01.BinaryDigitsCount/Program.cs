﻿using System;

namespace _01.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int count = 0;

            while (n != 0)
            {
                int binaryDigit = n & 1;

                if (binaryDigit == b)
                {
                    count++;
                }

                n = n >> 1;
            }

            Console.WriteLine(count);
        }
    }
}
