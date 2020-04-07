using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            Dictionary<string, int> trekking = new Dictionary<string, int>()
            {
                {"Musala", 0},
                {"Monblan", 0},
                {"Kilimandjaro", 0},
                {"K2", 0},
                {"Everest",0}
            };

            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());

                if (people <= 5)
                {
                    trekking["Musala"] += people;
                }
                else if (people >= 6 && people <= 12)
                {
                    trekking["Monblan"] += people;
                }
                else if (people >=13 && people <= 25)
                {
                    trekking["Kilimandjaro"] += people;
                }
                else if (people >= 26 && people <= 40)
                {
                    trekking["K2"] += people;
                }
                else
                {
                    trekking["Everest"] += people;
                }
            }

            int allPeople = trekking.Sum(x => x.Value);

            foreach (var kvp in trekking)
            {
                Console.WriteLine($"{(((double)kvp.Value/allPeople)*100):f2}%");
            }
        }
    }
}
