using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racersNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> racers = new Dictionary<string, int>(racersNames.Length);

            foreach (string name in racersNames)
            {
                racers.Add(name, 0);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine())!= "end of race")
            {
                StringBuilder name = new StringBuilder();
                int distance = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        name.Append(input[i]);
                    }
                    else if (char.IsDigit(input[i]))
                    {
                        distance += int.Parse(input[i].ToString());
                    }
                }

                if (racers.ContainsKey(name.ToString()))
                {
                    racers[name.ToString()] += distance;
                }
            }

            List<string> topRacers = racers
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .Take(3)
                .ToList();

            Console.WriteLine($"1st place: {topRacers[0]}");
            Console.WriteLine($"2nd place: {topRacers[1]}");
            Console.WriteLine($"3rd place: {topRacers[2]}");
        }
    }
}
