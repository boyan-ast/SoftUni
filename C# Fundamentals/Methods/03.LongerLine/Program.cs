using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstX = double.Parse(Console.ReadLine());
            double firstY = double.Parse(Console.ReadLine());            

            double secondX = double.Parse(Console.ReadLine());
            double secondY = double.Parse(Console.ReadLine());

            double firstSideA = CalculateSide(firstX, secondX);
            double firstSideB = CalculateSide(firstY, secondY);

            double firstLine = Math.Sqrt(Math.Pow(firstSideA, 2) + Math.Pow(firstSideB, 2));
            //Console.WriteLine(firstLine);

            double thirdX = double.Parse(Console.ReadLine());
            double thirdY = double.Parse(Console.ReadLine());            

            double fourthX = double.Parse(Console.ReadLine());
            double fourthY = double.Parse(Console.ReadLine());

            double secondSideA = CalculateSide(thirdX, fourthX);
            double secondSideB = CalculateSide(thirdY, fourthY);

            double secondLine = Math.Sqrt(Math.Pow(secondSideA, 2) + Math.Pow(secondSideB, 2));
            //Console.WriteLine(secondLine);

            if (firstLine >= secondLine)
            {
                if (CalculateDistanceToOrigin(firstX, firstY) <=
                CalculateDistanceToOrigin(secondX, secondY))
                {
                    Console.WriteLine($"({firstX}, {firstY})({secondX}, {secondY})");
                }
                else
                {
                    Console.WriteLine($"({secondX}, {secondY})({firstX}, {firstY})");
                }
            }
            else
            {
                if (CalculateDistanceToOrigin(thirdX, thirdY) <=
                CalculateDistanceToOrigin(fourthX, fourthY))
                {
                    Console.WriteLine($"({thirdX}, {thirdY})({fourthX}, {fourthY})");
                }
                else
                {
                    Console.WriteLine($"({fourthX}, {fourthY})({thirdX}, {thirdY})");
                }
            }

        }

        private static double CalculateDistanceToOrigin(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        private static double CalculateSide(double x1, double x2)
        {
            if ((x1 >= 0 && x2 <= 0) ||
                (x1 <= 0 && x2 >=0))
            {
                return Math.Abs(Math.Abs(x1) + Math.Abs(x2));
            }
            else if ((x1 >= 0 && x2 >= 0) ||
                (x1 <= 0 && x2 <= 0))
            {
                return Math.Abs(Math.Abs(x1) - Math.Abs(x2));
            }
            else
            {
                return 0;
            }
        }
    }
}
