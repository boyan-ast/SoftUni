using System;

namespace _03.Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drinkType = Console.ReadLine();
            string sugarAmount = Console.ReadLine();
            int drinksNumber = int.Parse(Console.ReadLine());

            double price = DrinkCalculator(drinkType, sugarAmount);

            double totalPrice = price * drinksNumber;

            if (sugarAmount == "Without")
            {
                totalPrice *= 0.65;
            }

            if (drinkType == "Espresso" && drinksNumber >= 5)
            {
                totalPrice *= 0.75;
            }

            if (totalPrice > 15)
            {
                totalPrice *= 0.80;
            }

            Console.WriteLine($"You bought {drinksNumber} cups of {drinkType} for {totalPrice:f2} lv.");

        }

        private static double DrinkCalculator(string drink, string sugar)
        {
            if (drink == "Espresso")
            {
                if (sugar == "Without")
                {
                    return 0.9;
                }
                else if (sugar == "Normal")
                {
                    return 1;
                }
                else if (sugar == "Extra")
                {
                    return 1.20;
                }
                else
                {
                    return 0;
                }
            }
            else if (drink == "Cappuccino")
            {
                if (sugar == "Without")
                {
                    return 1;
                }
                else if (sugar == "Normal")
                {
                    return 1.20;
                }
                else if (sugar == "Extra")
                {
                    return 1.60;
                }
                else
                {
                    return 0;
                }
            }
            else if (drink == "Tea")
            {
                if (sugar == "Without")
                {
                    return 0.50;
                }
                else if (sugar == "Normal")
                {
                    return 0.60;
                }
                else if (sugar == "Extra")
                {
                    return 0.70;
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
