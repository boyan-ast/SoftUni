using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double totalPrice = CalculatePrice(product, quantity);
            Console.WriteLine($"{totalPrice:f2}");
        }

        static double CalculatePrice(string product, int quantity)
        {
            double price = 0;

            switch (product)
            {
                case "water": price = 1; break;
                case "coke": price = 1.40; break;
                case "coffee": price = 1.5; break;
                case "snacks": price = 2; break;
                default: break;
            }

            return price * quantity;
        }
    }
}
