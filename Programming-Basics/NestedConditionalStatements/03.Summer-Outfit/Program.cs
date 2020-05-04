using System;
using System.Runtime.InteropServices.ComTypes;

namespace _03.Summer_Outfit
{
    class Program
    {
        static string outfit = string.Empty;
        static string shoes = string.Empty;
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string daytime = Console.ReadLine();

            DefineSummerOutfit(degrees, daytime);

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }

        private static void DefineSummerOutfit(int degrees, string daytime)
        {
            if (degrees >= 10 && degrees <= 18)
            {
                if (daytime == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (daytime == "Afternoon" || daytime == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                if (daytime == "Morning" || daytime == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (daytime == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }
            else if (degrees > 24)
            {
                if (daytime == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (daytime == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (daytime == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
        }
    }
}
