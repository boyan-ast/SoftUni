using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            Dictionary<string, int> climbers = new Dictionary<string, int>()
            {
                { "Musala", 0 },
                { "Monblan", 0 },
                { "Kilimanjaro", 0 },
                { "K2", 0 },
                { "Everest", 0 }
            };

            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());

                if (people <= 5)
                {
                    climbers["Musala"] += people;
                }
                else if (people <= 12)
                {
                    climbers["Monblan"] += people;
                }
                else if (people <= 25)
                {
                    climbers["Kilimanjaro"] += people;
                }
                else if (people <= 40)
                {
                    climbers["K2"] += people;
                }
                else
                {
                    climbers["Everest"] += people;
                }
            }

            int totalClimbers = climbers.Sum(x => x.Value);

            foreach (var kvp in climbers)
            {
                Console.WriteLine($"{((kvp.Value) * 1.0 / totalClimbers * 100):f2}%");
            }
        }
    }
}
