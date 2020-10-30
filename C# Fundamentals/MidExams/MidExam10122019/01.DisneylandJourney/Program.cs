using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double savingsPerMonth = journeyCost * 0.25;
            double savedMoney = savingsPerMonth;

            for (int i = 2; i <= months; i++)
            {
                if (i % 2 != 0)
                {
                    savedMoney *= 0.84;
                }
                else if (i % 4 == 0)
                {
                    savedMoney += 0.25 * savedMoney;
                }

                savedMoney += savingsPerMonth;
            }

            double moneyDiff = journeyCost - savedMoney;

            if (moneyDiff <= 0)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {-moneyDiff:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {moneyDiff:f2}lv. more.");
            }
        }
    }
}
