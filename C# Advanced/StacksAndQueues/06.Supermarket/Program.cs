using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> supermarketQueue = new Queue<string>();

            string name = string.Empty;

            while ((name = Console.ReadLine()) != "End")
            {
                if (name == "Paid")
                {
                    while (supermarketQueue.Count > 0)
                    {
                        Console.WriteLine(supermarketQueue.Dequeue());
                    }
                }
                else
                {
                    supermarketQueue.Enqueue(name);
                }
            }

            Console.WriteLine($"{supermarketQueue.Count} people remaining.");
        }
    }
}
