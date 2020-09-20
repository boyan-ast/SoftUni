using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            decimal discaneInKm = (decimal) distanceInMeters / 1000;

            Console.WriteLine($"{discaneInKm:f2}");
        }
    }
}
