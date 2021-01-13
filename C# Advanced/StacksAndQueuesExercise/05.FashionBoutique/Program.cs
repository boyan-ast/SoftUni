using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int capacity = int.Parse(Console.ReadLine());

            int count = 0;
            int sum = 0;

            while (stack.Count > 0)
            {
                int current = stack.Peek();

                if (sum + current == capacity)
                {
                    count++;
                    stack.Pop();
                    sum = 0;
                }
                else if (sum + current > capacity)
                {
                    count++;
                    sum = 0;
                }
                else
                {
                    stack.Pop();
                    sum += current;
                }

            }

            if (sum != 0)
            {
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
