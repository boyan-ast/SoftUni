using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>(peopleData.Length);

            AddBuyers(peopleData, people);

            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>(productsData.Length);

            AddProducts(productsData, products);

            BuyProducts(people, products);

            PrintProductBags(people);
        }

        private static void PrintProductBags(List<Person> people)
        {
            foreach (Person person in people)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - " + string.Join(", ", person.BagOfProducts));
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }

        static void BuyProducts(List<Person> people, List<Product> products)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string person = commandArgs[0];
                string item = commandArgs[1];

                Person buyer = people.First(x => x.Name == person);
                Product product = products.First(x => x.Name == item);

                buyer.BuyProduct(product);
            }
        }
        private static void AddProducts(string[] productsData, List<Product> products)
        {
            foreach (string item in productsData)
            {
                string[] itemData = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = itemData[0];
                int cost = int.Parse(itemData[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }

        private static void AddBuyers(string[] peopleData, List<Person> people)
        {
            foreach (string buyer in peopleData)
            {
                string[] personData = buyer.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int money = int.Parse(personData[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> BagOfProducts { get; set; }

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost <= Money)
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                BagOfProducts.Add(product);
                Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
