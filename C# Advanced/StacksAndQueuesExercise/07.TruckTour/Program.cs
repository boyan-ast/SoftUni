using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolPump> pumps = new Queue<PetrolPump>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pumpInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int amount = pumpInfo[0];
                int distance = pumpInfo[1];

                PetrolPump pump = new PetrolPump(i, amount, distance);

                pumps.Enqueue(pump);
            }

            int tank = 0;
            List<int> visited = new List<int>(n);

            while (true)
            {
                PetrolPump currentPump = pumps.Dequeue();
                int pumpPetrol = currentPump.PetrolAmount;
                int distanceToNext = currentPump.DistanceToNext;

                tank += pumpPetrol;

                if (tank < distanceToNext)
                {
                    if (currentPump.Number == n - 1)
                    {
                        break;
                    }
                    visited = new List<int>(n);
                    tank = 0;
                }
                else
                {
                    tank -= distanceToNext;

                    visited.Add(currentPump.Number);

                    if (visited.Count == n)
                    {
                        Console.WriteLine(visited[0]);
                        break;
                    }
                }

                pumps.Enqueue(currentPump);
            }

        }
    }


    class PetrolPump
    {
        public PetrolPump(int number, int amount, int distance)
        {
            Number = number;
            PetrolAmount = amount;
            DistanceToNext = distance;
        }

        public int Number { get; set; }
        public int PetrolAmount { get; set; }
        public int DistanceToNext { get; set; }
    }
}
