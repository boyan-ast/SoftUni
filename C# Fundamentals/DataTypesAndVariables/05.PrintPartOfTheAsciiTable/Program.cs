using System;

namespace _05.PrintPartOfTheAsciiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (char symbol = (char)start; symbol <= end; symbol++)
            {
                Console.Write($"{symbol} ");
            }
        }
    }
}
