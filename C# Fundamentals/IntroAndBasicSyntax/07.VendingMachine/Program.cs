using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(command);

                if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1 && coins != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    continue;
                }

                totalMoney += coins;
            }

            while ((command = Console.ReadLine()) != "End")
            {
                BuyingProducts(command, ref totalMoney);
            }

            Console.WriteLine($"Change: {totalMoney:f2}");
        }

        private static void BuyingProducts(string product, ref double money)
        {
            bool successfulPurchase = false;

            if (product != "Nuts" && 
                product != "Water" && 
                product != "Crisps" && 
                product != "Soda" && 
                product != "Coke")
            {
                Console.WriteLine("Invalid product");
                return;
            }

            if (product == "Nuts" && money >= 2)
            {
                successfulPurchase = true;
                money -= 2;
            }
            else if (product == "Water" && money >= 0.7)
            {
                successfulPurchase = true;
                money -= 0.7;
            }
            else if (product == "Crisps" && money >= 1.5)
            {
                successfulPurchase = true;
                money -= 1.5;
            }
            else if (product == "Soda" && money >= 0.8)
            {
                successfulPurchase = true;
                money -= 0.8;
            }
            else if (product == "Coke" && money >= 1)
            {
                successfulPurchase = true;
                money -= 1;
            }

            if (successfulPurchase)
            {
                Console.WriteLine($"Purchased {product.ToLower()}");
            }
            else
            {
                Console.WriteLine("Sorry, not enough money");
            }
        }
    }
}
