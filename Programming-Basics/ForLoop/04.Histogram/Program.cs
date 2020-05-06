using System;
using System.Collections.Generic;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            Dictionary<string, int> histogramData = new Dictionary<string, int>
            {
                { "firstRange", 0 },
                { "secondRange", 0 },
                { "thirdRange", 0 },
                { "fourthRange", 0 },
                { "fifthRange", 0 }

            };

            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    histogramData["firstRange"]++;
                }
                else if (number < 400)
                {
                    histogramData["secondRange"]++;
                }
                else if (number < 600)
                {
                    histogramData["thirdRange"]++;
                }
                else if (number < 800)
                {
                    histogramData["fourthRange"]++;
                }
                else
                {
                    histogramData["fifthRange"]++;
                }
            }

            Console.WriteLine($"{(histogramData["firstRange"]*1.0/ numbers * 100):f2}%");
            Console.WriteLine($"{(histogramData["secondRange"] * 1.0 / numbers * 100):f2}%");
            Console.WriteLine($"{(histogramData["thirdRange"] * 1.0 / numbers * 100):f2}%");
            Console.WriteLine($"{(histogramData["fourthRange"] * 1.0 / numbers * 100):f2}%");
            Console.WriteLine($"{(histogramData["fifthRange"] * 1.0 / numbers * 100):f2}%");

        }
    }
}
