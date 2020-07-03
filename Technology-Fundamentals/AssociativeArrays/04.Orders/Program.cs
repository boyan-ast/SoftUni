using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> orders = new List<Product>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] productInfo = command.Split();
                string name = productInfo[0];
                double price = double.Parse(productInfo[1]);
                int quantity = int.Parse(productInfo[2]);                

                if (!orders.Select(x => x.Name).Contains(name))
                {
                    Product product = new Product(name, price, quantity);
                    orders.Add(product);
                }
                else
                {
                    orders.First(x => x.Name == name).Price = price;
                    orders.First(x => x.Name == name).Quantity += quantity;
                }                
            }

            foreach (Product item in orders)
            {
                Console.WriteLine(item);
            }
        }

        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }

            public Product(string name, double price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public override string ToString()
            {
                return $"{Name} -> {(Quantity * Price):f2}";
            }
        }
    }
}
