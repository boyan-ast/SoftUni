using System;
using System.Data;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int percentWithoutPaint = int.Parse(Console.ReadLine());

            double totalArea = height * width * 4;
            totalArea *= (100 - percentWithoutPaint) / 100.00;
            totalArea = Math.Ceiling(totalArea);

            string command = null;

            while ((command = Console.ReadLine()) != "Tired!")
            {
                int paintVolume = int.Parse(command);
                totalArea -= paintVolume;

                if (totalArea == 0)
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    return;
                }
                else if (totalArea < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {-totalArea} l paint left!");
                    return;
                }
            }

            Console.WriteLine($"{totalArea} quadratic m left.");
        }
    }
}
