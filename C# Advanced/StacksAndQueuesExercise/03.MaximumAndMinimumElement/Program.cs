using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int commandType = input[0];

                switch (commandType)
                {
                    case 1:
                        int element = input[1];
                        stack.Push(element);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        Stack<int> copiedStack = new Stack<int>(stack);
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(FindTheMaxElement(copiedStack));
                        }
                        break;
                    case 4:
                        copiedStack = new Stack<int>(stack);
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(FindTheMinElement(copiedStack));
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }

        private static int FindTheMaxElement(Stack<int> stack)
        {
            int max = stack.Pop();

            while (stack.Count > 0)
            {
                int current = stack.Pop();

                if (current > max)
                {
                    max = current;
                }
            }

            return max;
        }

        private static int FindTheMinElement(Stack<int> stack)
        {
            int min = stack.Pop();

            while (stack.Count > 0)
            {
                int current = stack.Pop();

                if (current < min)
                {
                    min = current;
                }
            }

            return min;
        }
    }
}
