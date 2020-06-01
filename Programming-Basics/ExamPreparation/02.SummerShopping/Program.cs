using System;

namespace _02.SummerShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            double towelPrice = double.Parse(Console.ReadLine());
            int discountPercent = int.Parse(Console.ReadLine());

            double umbrellaPrice = 2.00 / 3 * towelPrice;
            double flipflopsPrice = 0.75 * umbrellaPrice;
            double bagPrice = 1.00 / 3 * (flipflopsPrice + towelPrice);

            double spentMoney = towelPrice + umbrellaPrice + flipflopsPrice + bagPrice;
            spentMoney *= (100 - discountPercent) * 1.0 / 100;

            if (budget >= spentMoney)
            {
                Console.WriteLine($"Annie's sum is {spentMoney:f2} lv. She has {(budget - spentMoney):f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {spentMoney:f2} lv. She needs {(spentMoney - budget):f2} lv. more.");
            }
        }
    }
}
