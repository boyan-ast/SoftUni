using System;

namespace _10.Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            double pricePerNight = 0;

            if (roomType == "room for one person")
            {
                pricePerNight = 18;
            }
            else if (roomType == "apartment")
            {
                pricePerNight = 25;
            }
            else if (roomType == "president apartment")
            {
                pricePerNight = 35;
            }

            double totalPrice = pricePerNight * (days - 1);

            double discount = DiscountCalculator(roomType, days);

            totalPrice *= (100 - discount) / 100;

            if (rating == "positive")
            {
                totalPrice *= 1.25;
            }
            else if (rating == "negative")
            {
                totalPrice *= 0.9;
            }

            Console.WriteLine($"{totalPrice:f2}");

        }

        private static double DiscountCalculator(string room, int days)
        {
            double discount = 0;

            if (days < 10)
            {
                if (room == "apartment")
                {
                    discount = 30;
                }
                else if (room == "president apartment")
                {
                    discount = 10;
                }
            }
            else if (days >= 10 && days <= 15)
            {
                if (room == "apartment")
                {
                    discount = 35;
                }
                else if (room == "president apartment")
                {
                    discount = 15;
                }
            }
            else
            {
                if (room == "apartment")
                {
                    discount = 50;
                }
                else if (room == "president apartment")
                {
                    discount = 20;
                }
            }

            return discount;

        }
    }
}
