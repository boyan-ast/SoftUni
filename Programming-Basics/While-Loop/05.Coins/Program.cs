using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());
            int coins = 0;
            decimal[] coinsTypes = new decimal[]
            {
                2, 1, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m
            };

            while (change != 0)
            {

                for (int i = 0; i < coinsTypes.Length; i++)
                {
                    if (change - coinsTypes[i] >= 0)
                    {
                        coins++;
                        change -= coinsTypes[i];
                        break;
                    }
                }
            }

            Console.WriteLine(coins);

        }
    }
}
