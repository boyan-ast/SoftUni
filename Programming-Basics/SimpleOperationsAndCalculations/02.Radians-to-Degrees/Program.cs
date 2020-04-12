using System;

namespace _02.Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double angleInRad = double.Parse(Console.ReadLine());

            double angleInDeg = angleInRad * 180 / Math.PI;

            Console.WriteLine(Math.Round(angleInDeg));
        }
    }
}
