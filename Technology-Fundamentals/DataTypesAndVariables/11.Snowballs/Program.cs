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
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;
            BigInteger bestSnowballValue = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentValue = snowballSnow / snowballTime;
                BigInteger snowballValue = 1;

                for (int j = 0; j < snowballQuality; j++)
                {
                    snowballValue *= currentValue;
                }

                if (snowballQuality == 0)
                {
                    snowballValue = 1;
                }

                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballValue = snowballValue;
                    bestSnowballQuality = snowballQuality;
                }                
            }

            Console.WriteLine("{0} : {1} = {2:f0} ({3})", bestSnowballSnow, bestSnowballTime, bestSnowballValue, bestSnowballQuality);
        }
    }
}
