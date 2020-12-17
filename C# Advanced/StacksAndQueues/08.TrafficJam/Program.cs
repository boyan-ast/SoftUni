using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int n = int.Parse(Console.ReadLine());

            int count = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        count++;

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
