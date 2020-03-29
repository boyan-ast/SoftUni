using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double requiredIncome = double.Parse(Console.ReadLine());

            string coctail = null;
            double totalIncome = 0;

            while ((coctail = Console.ReadLine()) != "Party!")
            {
                double coctailPrice = coctail.Length;
                int numberOfCoctails = int.Parse(Console.ReadLine());
                double orderPrice = coctailPrice * numberOfCoctails;

                if (orderPrice % 2 != 0)
                {
                    orderPrice *= 0.75;
                }

                totalIncome += orderPrice;

                if (totalIncome >= requiredIncome)
                {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {totalIncome:f2} leva.");
                    return;
                }
            }

            Console.WriteLine($"We need {(requiredIncome-totalIncome):f2} leva more.");
            Console.WriteLine($"Club income - {totalIncome:f2} leva.");
        }
    }
}
