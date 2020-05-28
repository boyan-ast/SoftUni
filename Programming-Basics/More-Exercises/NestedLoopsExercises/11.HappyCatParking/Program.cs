using System;

namespace _11.HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());

            double totalSum = 0;

            for (int day = 1; day <= days; day++)
            {
                double pricePerDay = 0;

                for (int hour = 1; hour <= hoursPerDay; hour++)
                {
                    double pricePerHour = 0;

                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        pricePerHour = 2.5;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        pricePerHour = 1.25;
                    }
                    else
                    {
                        pricePerHour = 1;
                    }

                    pricePerDay += pricePerHour;
                }

                totalSum += pricePerDay;

                Console.WriteLine($"Day: {day} - {pricePerDay:f2} leva");
            }

            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
