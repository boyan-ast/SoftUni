using System;

namespace _04.BeehivePopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int population = int.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());

            for (int year = 1; year <= years; year++)
            {
                int bornBees = (population / 10) * 2;
                population += bornBees;

                if (year % 5 == 0)
                {
                    int leavingBees = (population / 50) * 5;
                    population -= leavingBees;
                }

                int deadBees = (population / 20) * 2;
                population -= deadBees;
            }

            Console.WriteLine($"Beehive population: {population}");
        }
    }
}
