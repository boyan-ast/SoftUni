using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> totalPriceCalc = PriceCalculator;

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .Select(totalPriceCalc)
                .ToArray();

            Array.ForEach(prices, p => Console.WriteLine("{0:f2}", p));
        }

        static double PriceCalculator(double price)
        {
            return price * 1.2;
        }
    }
}
