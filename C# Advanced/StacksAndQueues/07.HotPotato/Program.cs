using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();

            Queue<string> circle = new Queue<string>(kids);

            int n = int.Parse(Console.ReadLine());

            while (circle.Count > 1)
            {
                int count = 1;

                while (count < n)
                {
                    circle.Enqueue(circle.Dequeue());
                    count++;
                }

                Console.WriteLine($"Removed {circle.Dequeue()}");
            }

            Console.WriteLine($"Last is {circle.Dequeue()}");
        }
    }
}
