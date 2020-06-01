using System;

namespace _03.CruiseShip
{
    class Program
    {
        static void Main(string[] args)
        {
            string cruiseType = Console.ReadLine();
            string cabinType = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double pricePerNight = CalculatePrice(cruiseType, cabinType);

            double totalPrice = 4 * nights * pricePerNight;

            if (nights > 7)
            {
                totalPrice *= 0.75;
            }

            Console.WriteLine($"Annie's holiday in the {cruiseType} sea costs {totalPrice:f2} lv.");
        }

        private static double CalculatePrice(string cruiseType, string cabinType)
        {
            if (cruiseType == "Mediterranean")
            {
                if (cabinType == "standard cabin")
                {
                    return 27.50;
                }
                else if (cabinType == "cabin with balcony")
                {
                    return 30.20;
                }
                else if (cabinType == "apartment")
                {
                    return 40.50;
                }
                else
                {
                    return 0;
                }
            }
            else if (cruiseType == "Adriatic")
            {
                if (cabinType == "standard cabin")
                {
                    return 22.99;
                }
                else if (cabinType == "cabin with balcony")
                {
                    return 25.00;
                }
                else if (cabinType == "apartment")
                {
                    return 34.99;
                }
                else
                {
                    return 0;
                }
            }
            else if (cruiseType == "Aegean")
            {
                if (cabinType == "standard cabin")
                {
                    return 23.00;
                }
                else if (cabinType == "cabin with balcony")
                {
                    return 26.60;
                }
                else if (cabinType == "apartment")
                {
                    return 39.80;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
