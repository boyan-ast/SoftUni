using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());

            if (CalculateDistanceToOrigin(firstPointX, firstPointY) <= 
                CalculateDistanceToOrigin(secondPointX, secondPointY))
            {
                Console.WriteLine($"({firstPointX}, {firstPointY})");
            }
            else
            {
                Console.WriteLine($"({secondPointX}, {secondPointY})");
            }
        }

        private static double CalculateDistanceToOrigin(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
