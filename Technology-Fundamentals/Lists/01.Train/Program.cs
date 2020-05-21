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

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                AddingPassengers(wagons, tokens, capacity);
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void AddingPassengers(List<int> wagons, string[] tokens, int capacity)
        {
            int passengers = 0;

            if (tokens[0] == "Add")
            {
                passengers = int.Parse(tokens[1]);
                wagons.Add(passengers);
            }
            else if (int.TryParse(tokens[0], out passengers))
            {
                for (int i = 0; i < wagons.Count; i++)
                {
                    if (wagons[i] + passengers <= capacity)
                    {
                        wagons[i] += passengers;
                        break;
                    }
                }
            }
        }
    }
}
