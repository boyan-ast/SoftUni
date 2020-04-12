using System;

namespace _07.Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double litersBeer = double.Parse(Console.ReadLine());
            double litersWine = double.Parse(Console.ReadLine());
            double litersRakia = double.Parse(Console.ReadLine());
            double litersWhiskey = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskeyPrice * 0.5;
            double winePrice = 0.6 * rakiaPrice;
            double beerPrice = 0.2 * rakiaPrice;

            double totalPrice = whiskeyPrice * litersWhiskey + rakiaPrice * litersRakia + winePrice * litersWine + beerPrice * litersBeer;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
