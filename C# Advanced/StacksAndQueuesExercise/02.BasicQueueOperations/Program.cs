using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
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
            int elementsToDequeue = input[1];
            int element = input[2];

            int[] elementsToEnqueue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elementsToEnqueue[i]);
            }

            while (elementsToDequeue > 0 && queue.Count > 0)
            {
                queue.Dequeue();
                elementsToDequeue--;
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(queue.Count);
            }
            else
            {
                bool containsElement = queue.Contains(element);

                if (containsElement)
                {
                    Console.WriteLine(containsElement.ToString().ToLower());
                }
                else
                {
                    int min = FindTheMinElement(queue);
                    Console.WriteLine(min);
                }
            }
        }

        private static int FindTheMinElement(Queue<int> queue)
        {
            int min = queue.Dequeue();

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current < min)
                {
                    min = current;
                }
            }

            return min;
        }
    }
}
