using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[]A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";

            Regex furnitureRegex = new Regex(pattern);

            List<string> furniture = new List<string>();

            double totalPrice = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Purchase")
            {

                Match match = furnitureRegex.Match(command);

                if (match.Success)
                {
                    string name = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furniture.Add(name);

                    totalPrice += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (string item in furniture)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
