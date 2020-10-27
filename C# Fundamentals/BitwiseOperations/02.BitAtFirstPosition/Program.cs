using System;

namespace _02.BitAtFirstPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int bitAtFirstPosition = (n >> 1) & 1;

            Console.WriteLine(bitAtFirstPosition);
        }
    }
}
