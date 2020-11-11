using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+(.\d+)?)\$";
            double totalIncome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match productInfo = Regex.Match(input, pattern);
                    string customerName = productInfo.Groups["customer"].Value;
                    string product = productInfo.Groups["product"].Value;
                    int count = int.Parse(productInfo.Groups["count"].Value);
                    double price = double.Parse(productInfo.Groups["price"].Value);

                    double totalPrice = count * price;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
                    totalIncome += totalPrice;
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
