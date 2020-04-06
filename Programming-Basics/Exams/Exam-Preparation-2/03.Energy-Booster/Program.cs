using System;

namespace _03.Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruitType = Console.ReadLine();
            string setSize = Console.ReadLine();
            int numberOfSets = int.Parse(Console.ReadLine());

            double itemPrice = PriceCalculator(fruitType, setSize);
            double totalPrice = itemPrice * numberOfSets;

            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                totalPrice *= 0.85;
            }
            else if (totalPrice > 1000)
            {
                totalPrice *= 0.5;
            }

            Console.WriteLine($"{totalPrice:f2} lv.");

        }

        private static double PriceCalculator(string fruit, string size)
        {
            if (fruit == "Watermelon")
            {
                if (size == "small")
                {
                    return 2 * 56.00;
                }
                else if (size == "big")
                {
                    return 5 * 28.70;
                }
                else
                {
                    return 0;
                }
            }
            else if (fruit == "Mango")
            {

                if (size == "small")
                {
                    return 2 * 36.66;
                }
                else if (size == "big")
                {
                    return 5 * 19.60;
                }
                else
                {
                    return 0;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (size == "small")
                {
                    return 2 * 42.10;
                }
                else if (size == "big")
                {
                    return 5 * 24.80;
                }
                else
                {
                    return 0;
                }
            }
            else if (fruit == "Raspberry")
            {

                if (size == "small")
                {
                    return 2 * 20.00;
                }
                else if (size == "big")
                {
                    return 5 * 15.20;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
