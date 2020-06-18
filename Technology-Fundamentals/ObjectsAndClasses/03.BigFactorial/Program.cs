﻿using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger result = 1;

            for (int i = number; i >= 2; i--)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
