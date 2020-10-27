using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEfficiency = int.Parse(Console.ReadLine());
            int secondEfficiency = int.Parse(Console.ReadLine());
            int thirdEfficiency = int.Parse(Console.ReadLine());

            int peoplePerHour = firstEfficiency + secondEfficiency + thirdEfficiency;

            int people = int.Parse(Console.ReadLine());
            int hours = 0;

            while(people > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }

                people -= peoplePerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
