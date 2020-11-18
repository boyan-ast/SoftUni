using System;
using System.Linq;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());

            int start = Math.Min(startChar, endChar);
            int end = Math.Max(startChar, endChar);

            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > start && input[i] < end)
                {
                    sum += input[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
