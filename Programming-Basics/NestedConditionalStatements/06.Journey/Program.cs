using System;

namespace _06.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = string.Empty;
            string holidayType = string.Empty;
            double price = 0;

            if (season == "summer")
            {
                holidayType = "Camp";
            }
            else if (season == "winter")
            {
                holidayType = "Hotel";
            }

            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    price = 0.3 * budget;
                }
                else if (season == "winter")
                {
                    price = 0.7 * budget;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    price = 0.4 * budget;
                }
                else if (season == "winter")
                {
                    price = 0.8 * budget;
                }
            }
            else
            {
                destination = "Europe";
                holidayType = "Hotel";
                price = 0.9 * budget;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayType} - {price:f2}");
        }
    }
}
