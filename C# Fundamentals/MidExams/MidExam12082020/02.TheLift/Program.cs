using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isFull = true;

            for (int wagon = 0; wagon < lift.Length; wagon++)
            {
                int availableSpots = 4 - lift[wagon];

                if (availableSpots != 0)
                {
                    if (people - availableSpots < 0)
                    {
                        lift[wagon] += people;
                        Console.WriteLine("The lift has empty spots!");
                        isFull = false;
                        break;
                    }
                    else
                    {
                        lift[wagon] = 4;
                        people -= availableSpots;
                    }
                }
            }

            if (people > 0 && isFull)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }

            Console.WriteLine(string.Join(" ", lift));
        }
    }
}
