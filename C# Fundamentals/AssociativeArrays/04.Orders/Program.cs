using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            BuyProducts(products);

            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        private static void BuyProducts(List<Product> products)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] productInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = productInfo[0];
                double price = double.Parse(productInfo[1]);
                int quantity = int.Parse(productInfo[2]);

                Product existingProduct = products.FirstOrDefault(x => x.Name == name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity += quantity;
                    existingProduct.Price = price;
                }
                else
                {
                    Product newProduct = new Product();
                    newProduct.Name = name;
                    newProduct.Price = price;
                    newProduct.Quantity = quantity;
                    products.Add(newProduct);
                }
            }
        }
    }

    class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public Product()
        {
            Price = 0.0d;
        }

        public override string ToString()
        {
            return $"{Name} -> {(Price * Quantity):f2}";
        }

    }
}
