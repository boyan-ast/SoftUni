using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (string personInfo in peopleInfo)
                {
                    string[] personData = personInfo.Split('=');

                    Person person = new Person(personData[0], decimal.Parse(personData[1]));

                    people.Add(person);
                }

                foreach (string productInfo in productsInfo)
                {
                    string[] productData = productInfo.Split('=');

                    Product product = new Product(productData[0], decimal.Parse(productData[1]));

                    products.Add(product);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();

                string personName = input[0];
                string productName = input[1];

                Person selectedPerson = people.FirstOrDefault(x => x.Name == personName);
                Product selectedProduct = products.FirstOrDefault(x => x.Name == productName);

                if (selectedPerson == null || selectedProduct == null)
                {
                    continue;
                }

                selectedPerson.BuyProduct(selectedProduct);
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person.BoughtPoducts());
            }
            
        }
    }
}
