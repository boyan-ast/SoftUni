using System;

namespace _01.Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDayPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int competingFactoryProd = int.Parse(Console.ReadLine());

            int dailyProd = biscuitsPerDayPerWorker * workers;

            int totalProd = 0;

            for (int day = 1; day <= 30; day++)
            {
                if (day % 3 != 0)
                {
                    totalProd += dailyProd;
                }
                else
                {
                    double thirdDayProd = dailyProd * 0.75;                    
                    totalProd += (int)thirdDayProd;
                }
            }

            Console.WriteLine($"You have produced {totalProd} biscuits for the past month.");

            int prodDiff = totalProd - competingFactoryProd;

            double percentageDiff = 0;

            if (prodDiff > 0)
            {
                percentageDiff = prodDiff * 1.0 / competingFactoryProd * 100;
                
                Console.WriteLine($"You produce {percentageDiff:f2} percent more biscuits.");
            }
            else
            {
                percentageDiff = - prodDiff * 1.0 / competingFactoryProd * 100;

                Console.WriteLine($"You produce {percentageDiff:f2} percent less biscuits.");
            }
        }
    }
}
