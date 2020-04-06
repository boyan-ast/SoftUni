using System;

namespace _03.Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string inclusive = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            if (days > 7)
            {
                days--;
            }

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }

            double pricePerDay = 0d;
            int vipDiscountPercent = 0;

            if (town == "Bansko" || town == "Borovets")
            {
                if (inclusive == "withEquipment")
                {
                    pricePerDay = 100;
                    vipDiscountPercent = 10;
                }
                else if (inclusive == "noEquipment")
                {
                    pricePerDay = 80;
                    vipDiscountPercent = 5;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
            }
            else if (town == "Varna" || town == "Burgas")
            {
                if (inclusive == "withBreakfast")
                {
                    pricePerDay = 130;
                    vipDiscountPercent = 12;
                }
                else if (inclusive == "noBreakfast")
                {
                    pricePerDay = 100;
                    vipDiscountPercent = 7;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            if (vip == "yes")
            {
                pricePerDay = pricePerDay - pricePerDay * (vipDiscountPercent / 100.00);
            }

            double totalSum = pricePerDay * days;

            Console.WriteLine($"The price is {totalSum:f2}lv! Have a nice time!");
        }
    }
}
