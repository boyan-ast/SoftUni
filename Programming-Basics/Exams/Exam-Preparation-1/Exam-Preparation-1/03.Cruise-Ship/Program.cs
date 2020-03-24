using System;

namespace _03.Cruise_Ship
{
    class Program
    {
        static void Main(string[] args)
        {
            string cruiseType = Console.ReadLine();
            string cabinType = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            bool discount = false;

            double pricePerDay = 0;

            if (days > 7)
            {
                discount = true;
            }

            if (cruiseType == "Mediterranean")
            {
                if (cabinType == "standard cabin")
                {
                    pricePerDay = 27.50;
                }
                else if (cabinType == "cabin with balcony")
                {
                    pricePerDay = 30.20;
                }
                else if (cabinType == "apartment")
                {
                    pricePerDay = 40.50;
                }
            }
            else if (cruiseType == "Adriatic")
            {
                if (cabinType == "standard cabin")
                {
                    pricePerDay = 22.99;
                }
                else if (cabinType == "cabin with balcony")
                {
                    pricePerDay = 25.00;
                }
                else if (cabinType == "apartment")
                {
                    pricePerDay = 34.99;
                }
            }
            else if (cruiseType == "Aegean")
            {
                if (cabinType == "standard cabin")
                {
                    pricePerDay = 23.00;
                }
                else if (cabinType == "cabin with balcony")
                {
                    pricePerDay = 26.60;
                }
                else if (cabinType == "apartment")
                {
                    pricePerDay = 39.80;
                }
            }

            double totalPrice = pricePerDay * days * 4;

            if (discount)
            {
                totalPrice *= 0.75;
            }

            Console.WriteLine($"Annie's holiday in the {cruiseType} sea costs {totalPrice:f2} lv.");
        }
    }
}
