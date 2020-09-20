using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            int bestSnowballSnow = 0;
            int besSnowballTime = 0;
            int bestSnowballQuality = 0;
            BigInteger highestSnowballValue = 0;


            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = 1;

                for (int j = 0; j < snowballQuality; j++)
                {
                    snowballValue *= (snowballSnow / snowballTime);
                }

                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballValue = snowballValue;
                    bestSnowballSnow = snowballSnow;
                    besSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {besSnowballTime} = {highestSnowballValue} ({bestSnowballQuality})");
        }
    }
}
