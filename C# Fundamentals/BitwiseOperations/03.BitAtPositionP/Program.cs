using System;

namespace _03.BitAtPositionP
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int bitAtPositionP = (n >> p) & 1;

            Console.WriteLine(bitAtPositionP);
        }
    }
}
