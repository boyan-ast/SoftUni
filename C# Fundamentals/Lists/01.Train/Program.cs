using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            int capacity = int.Parse(Console.ReadLine());

            string command = string.Empty;

            while ((command = Console.ReadLine())!="end")
            {
                int passengers = 0;

                if (int.TryParse(command, out passengers))
                {
                    FitThePassengers(wagons, passengers, capacity);
                }
                else
                {
                    passengers = int.Parse((command.Split())[1]);
                    wagons.Add(passengers);
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FitThePassengers(List<int> wagons, int people, int capacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if ((wagons[i] + people) > capacity)
                {
                    continue;
                }
                else
                {
                    wagons[i] += people;
                    break;
                }
            }
        }
    }
}
