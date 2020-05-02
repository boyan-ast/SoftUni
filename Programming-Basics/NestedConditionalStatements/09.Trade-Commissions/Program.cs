using System;

namespace _09.Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commissionPercent = CommsionCalculator(town, sales);

            double commission = commissionPercent / 100 * sales;

            if (commission != 0)
            {
                Console.WriteLine($"{commission:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }

        }

        private static double CommsionCalculator(string town, double sales)
        {
            double commission = 0;

            if (sales >= 0 && sales <= 500)
            {
                if (town == "Sofia")
                {
                    commission = 5;
                }
                else if (town == "Varna")
                {
                    commission = 4.5;
                }
                else if (town == "Plovdiv")
                {
                    commission = 5.5;
                }
            }
            else if (sales > 500 && sales <= 1000)
            {
                if (town == "Sofia")
                {
                    commission = 7;
                }
                else if (town == "Varna")
                {
                    commission = 7.5;
                }
                else if (town == "Plovdiv")
                {
                    commission = 8;
                }
            }
            else if (sales > 1000 && sales <= 10000)
            {
                if (town == "Sofia")
                {
                    commission = 8;
                }
                else if (town == "Varna")
                {
                    commission = 10;
                }
                else if (town == "Plovdiv")
                {
                    commission = 12;
                }
            }
            else if (sales > 10000)
            {
                if (town == "Sofia")
                {
                    commission = 12;
                }
                else if (town == "Varna")
                {
                    commission = 13;
                }
                else if (town == "Plovdiv")
                {
                    commission = 14.5;
                }
            }

            return commission;
        }
    }
}
