using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> reversed = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                reversed.Push(input[i].ToString());
            }

            while (reversed.Count > 0)
            {
                Console.Write(reversed.Pop());
            }

            Console.WriteLine();
        }
    }
}
