using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int elementsToPop = input[1];
            int element = input[2];

            int[] elementsToPush = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(elementsToPush[i]);
            }

            while (elementsToPop > 0 && stack.Count > 0)
            {
                stack.Pop();
                elementsToPop--;
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
            
        }
    }
}
