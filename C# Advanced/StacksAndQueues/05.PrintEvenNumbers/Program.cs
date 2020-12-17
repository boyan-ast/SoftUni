using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                        
            Queue<int> queue = new Queue<int>();
            Queue<int> evenNums = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            while (queue.Count > 0)
            {
                int num = queue.Dequeue();

                if (num % 2 == 0)
                {
                    evenNums.Enqueue(num);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
