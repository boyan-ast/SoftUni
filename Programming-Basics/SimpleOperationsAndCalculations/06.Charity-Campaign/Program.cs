using System;

namespace _06.Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int chefs = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double cakesPrice = cakes * 45;
            double wafflesPrice = waffles * 5.80;
            double pancakesPrice = pancakes * 3.2;

            double productsPrice = cakesPrice + wafflesPrice + pancakesPrice;
            double totalIncome = days * chefs * productsPrice;
            totalIncome *= 7 / 8.00;

            Console.WriteLine($"{totalIncome:f2}");
        }
    }
}
