using System;

namespace _08.Fruit_Shop
{
    class Program
    {
        static double[,] productsPrice =
        {
            { 2.50, 1.20, 0.85, 1.45, 2.70, 5.50, 3.85 },
            { 2.70, 1.25, 0.90, 1.60, 3.0, 5.60, 4.20}
        };
            
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double finalPrice = quantity * PriceCalculator(fruit, dayOfWeek);

            if (finalPrice != 0)
            {
                Console.WriteLine($"{finalPrice:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        private static double PriceCalculator(string fruit, string day)
        {
            double price = 0;

            switch (fruit)
            {
                case "banana":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 0];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 0];
                            break;
                        default:
                            break;
                    }
                    break;
                case "apple":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 1];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 1];
                            break;
                        default:
                            break;
                    }
                    break;
                case "orange":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 2];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 2];
                            break;
                        default:
                            break;
                    }
                    break;
                case "grapefruit":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 3];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 3];
                            break;
                        default:
                            break;
                    }
                    break;
                case "kiwi":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 4];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 4];
                            break;
                        default:
                            break;
                    }
                    break;
                case "pineapple":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 5];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 5];
                            break;
                        default:
                            break;
                    }
                    break;
                case "grapes":
                    switch (day)
                    {
                        case "Monday":
                        case "Tuesday":
                        case "Wednesday":
                        case "Thursday":
                        case "Friday":
                            price = productsPrice[0, 6];
                            break;
                        case "Saturday":
                        case "Sunday":
                            price = productsPrice[1, 6];
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return price;

        }
    }
}
