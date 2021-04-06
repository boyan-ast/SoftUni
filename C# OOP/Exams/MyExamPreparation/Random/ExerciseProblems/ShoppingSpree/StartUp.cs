using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (string personInfo in peopleInput)
            {
                string[] info = personInfo.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                decimal money = decimal.Parse(info[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            foreach (string productInfo in productsInput)
            {
                string[] info = productInfo.Split('=');
                string name = info[0];
                decimal cost = decimal.Parse(info[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] buyerInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = buyerInfo[0];
                string productName = buyerInfo[1];

                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (person == null || product == null)
                {
                    continue;
                }

                if (person.Money >= product.Cost)
                {
                    Console.WriteLine(person.AddProductToBag(product));
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }

            foreach (Person person in people)
            {
                string productsBought = person.Products.Count != 0 ? 
                    string.Join(", ", person.Products) :
                    "Nothing bought";

                Console.WriteLine($"{person.Name} - {productsBought}");
            }

        }
    }
}
