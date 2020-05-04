using System;

namespace _05.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double shipPrice = ShipPriceCalculator(season);
            int discount = DiscountCalculator(fishermen);

            shipPrice *= (100 - discount) / 100.00;

            if (fishermen % 2 == 0 && season != "Autumn")
            {
                shipPrice *= 0.95;
            }

            double diff = budget - shipPrice;

            if (diff >= 0)
            {
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {-diff:f2} leva.");
            }
        }

        private static int DiscountCalculator(int people)
        {
            if (people <= 6)
            {
                return 10;
            }
            else if (people > 6 && people <= 11)
            {
                return 15;
            }
            else if (people > 11)
            {
                return 25;
            }
            else
            {
                return 0;
            }    
        }

        private static double ShipPriceCalculator(string season)
        {
            switch (season)
            {
                case "Spring": return 3000;
                case "Summer": 
                case "Autumn": return 4200;
                case "Winter": return 2600;
                default: return 0;
            }
        }
    }
}
