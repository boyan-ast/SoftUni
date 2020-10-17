using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            double budget = double.Parse(Console.ReadLine());

            List<double> newPrices = new List<double>(items.Length);
            double profit = 0;

            foreach (string item in items)
            {
                string[] itemData = item.Split("->");
                string type = itemData[0];
                double price = double.Parse(itemData[1]);
                double newPrice = 0;

                if ((type == "Clothes" && price <= 50 && price <= budget) || 
                    (type == "Shoes" && price <= 35 && price <= budget) ||
                    (type == "Accessories" && price <= 20.50 && price <= budget))
                {
                    budget -= price;
                    newPrice = price * 1.4;
                    profit += 0.4 * price;
                    newPrices.Add(newPrice);
                }                
            }

            budget += newPrices.Sum();

            StringBuilder newPricesText = new StringBuilder();

            foreach (double price in newPrices)
            {
                newPricesText.Append($"{price:f2} ");
            }

            newPricesText.ToString().Trim();

            Console.WriteLine(newPricesText);

            Console.WriteLine($"Profit: {profit:f2}");

            if (budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}
