using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();

            double totalPrice = 0.0d;
            Regex regex = new Regex(@">>(?<furniture>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)");

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    string name = regex.Match(input).Groups["furniture"].Value;
                    furniture.Add(name);
                    double price = double.Parse(regex.Match(input).Groups["price"].Value);
                    int quantity = int.Parse(regex.Match(input).Groups["quantity"].Value);

                    totalPrice += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (string item in furniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total money spend: {0:0.00}", totalPrice);
        }
    }
}
