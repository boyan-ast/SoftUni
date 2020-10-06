using System;
using System.Collections.Generic;

namespace _04.TribonacciSequence
{
    class Program
    {
        static List<long> trib = new List<long>();

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= num; i++)
            {
                trib.Add(CalculateTribonacci(i));
            }

            Console.WriteLine(string.Join(" ", trib));
        }

        private static long CalculateTribonacci(int n)
        {
            if (n < 3)
            {
                return 1;
            }
            else if (n == 3)
            {
                return 2;
            }
            else
            {
                return trib[n - 2] + trib[n - 3] + trib[n - 4];
            }
        }
    }
}
