using System;

namespace _04.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersNumber = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowerPrice = SingleFlowerPriceCalculator(flowersType);
            double totalPrice = flowerPrice * flowersNumber;

            int discount = DiscountCalculator(flowersType, flowersNumber);

            totalPrice *= (100 - discount) / 100.00;

            double diff = budget - totalPrice;

            if (diff >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersNumber} {flowersType} and {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {-diff:f2} leva more.");
            }

        }

        private static int DiscountCalculator(string flower, int number)
        {
            if (number > 80 && flower == "Roses")
            {
                return 10;
            }
            else if (number > 90 && flower == "Dahlias")
            {
                return 15;
            }
            else if (number > 80 && flower == "Tulips")
            {
                return 15;
            }
            else if (number < 120 && flower == "Narcissus")
            {
                return -15;
            }
            else if (number < 80 && flower == "Gladiolus")
            {
                return -20;
            }
            else
            {
                return 0;
            }
        }

        private static double SingleFlowerPriceCalculator(string flower)
        {
            switch (flower)
            {
                case "Roses":
                    return 5;
                case "Dahlias":
                    return 3.80;
                case "Tulips":
                    return 2.80;
                case "Narcissus":
                    return 3;
                case "Gladiolus":
                    return 2.50;
                default:
                    return 0;
            }
        }
    }
}
