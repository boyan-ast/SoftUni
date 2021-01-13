using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray());

            int biggestOrder = orders.Max();

            Console.WriteLine(biggestOrder);

            while (true)
            {
                int currentOrder = orders.Peek();

                if (foodQuantity - currentOrder >= 0)
                {
                    orders.Dequeue();
                    foodQuantity -= currentOrder;
                }
                else
                {
                    break;
                }

                if (orders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
            }

            if (orders.Count > 0)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", orders));
            }
        }
    }
}
