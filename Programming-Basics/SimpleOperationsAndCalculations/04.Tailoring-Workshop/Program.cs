using System;

namespace _04.Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int coversNumber = int.Parse(Console.ReadLine());
            double rectangeLength = double.Parse(Console.ReadLine());
            double rectangeWidth = double.Parse(Console.ReadLine());

            double squareSide = rectangeLength * 0.5;

            double rectangesArea = coversNumber * (rectangeLength + 0.6) * (rectangeWidth + 0.6);
            double squaresArea = coversNumber * Math.Pow(squareSide, 2);

            double priceInUsd = rectangesArea * 7 + squaresArea * 9;
            double priceInBgn = priceInUsd * 1.85;

            Console.WriteLine($"{priceInUsd:f2} USD");
            Console.WriteLine($"{priceInBgn:f2} BGN");
        }
    }
}
