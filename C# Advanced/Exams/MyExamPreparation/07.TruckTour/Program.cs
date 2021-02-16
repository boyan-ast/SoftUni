using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Pump> pumps = new Queue<Pump>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pumpInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int value = pumpInfo[0];
                int distanceToNext = pumpInfo[1];

                Pump pump = new Pump(i, value, distanceToNext);
                pumps.Enqueue(pump);
            }

            int count = 0;
            int fuel = 0;

            while (count < n)
            {
                Pump currentPump = pumps.Dequeue();
                fuel += currentPump.Value;

                if (fuel - currentPump.DistanceToNext < 0)
                {
                    fuel = 0;                    
                    count = 0;
                }
                else
                {
                    fuel -= currentPump.DistanceToNext;
                    count++;
                }

                pumps.Enqueue(currentPump);
            }

            Console.WriteLine(pumps.Dequeue().Number);
        }
    }

    public class Pump
    {
        public Pump(int number, int value, int distanceToNext)
        {
            Number = number;
            Value = value;
            DistanceToNext = distanceToNext;
        }

        public int Number { get; set; }
        public int Value { get; set; }
        public int DistanceToNext { get; set; }
    }
}
