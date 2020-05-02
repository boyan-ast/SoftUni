using System;

namespace _04.Small_Shop
{
    class Program
    {
        public static double[,] productsPrice =
        {
                { 0.50, 0.80, 1.20, 1.45, 1.60 },
                { 0.40, 0.70, 1.15, 1.30, 1.50 },
                { 0.45, 0.70, 1.10, 1.35, 1.55 }
        };

        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = quantity * SinglePriceCalculator(product, town);

            Console.WriteLine(price);
        }

        private static double SinglePriceCalculator(string product, string town)
        {
            double finalPrice = 0;

            if (product == "coffee")
            {
                if (town == "Sofia")
                {
                    finalPrice = productsPrice[0, 0];
                }
                else if (town == "Plovdiv")
                {
                    finalPrice = productsPrice[1, 0];
                }
                else if (town == "Varna")
                {
                    finalPrice = productsPrice[2, 0];
                }
            }
            else if (product == "water")
            {
                if (town == "Sofia")
                {
                    finalPrice = productsPrice[0, 1];
                }
                else if (town == "Plovdiv")
                {
                    finalPrice = productsPrice[1, 1];
                }
                else if (town == "Varna")
                {
                    finalPrice = productsPrice[2, 1];
                }
            }
            else if (product == "beer")
            {
                if (town == "Sofia")
                {
                    finalPrice = productsPrice[0, 2];
                }
                else if (town == "Plovdiv")
                {
                    finalPrice = productsPrice[1, 2];
                }
                else if (town == "Varna")
                {
                    finalPrice = productsPrice[2, 2];
                }
            }
            else if (product == "sweets")
            {
                if (town == "Sofia")
                {
                    finalPrice = productsPrice[0, 3];
                }
                else if (town == "Plovdiv")
                {
                    finalPrice = productsPrice[1, 3];
                }
                else if (town == "Varna")
                {
                    finalPrice = productsPrice[2, 3];
                }
            }
            else if (product == "peanuts")
            {
                if (town == "Sofia")
                {
                    finalPrice = productsPrice[0, 4];
                }
                else if (town == "Plovdiv")
                {
                    finalPrice = productsPrice[1, 4];
                }
                else if (town == "Varna")
                {
                    finalPrice = productsPrice[2, 4];
                }
            }

            return finalPrice;
        }
    }
}
