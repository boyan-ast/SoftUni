using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] productData = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = productData[0];
                string product = productData[1];
                double price = double.Parse(productData[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }

            shops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in shops)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var product in kvp.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
