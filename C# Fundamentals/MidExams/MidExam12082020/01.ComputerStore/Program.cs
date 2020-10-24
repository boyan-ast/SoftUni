using System;
using System.Data;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            string commad = Console.ReadLine();

            while (commad != "special" && commad != "regular")
            {
                double price = double.Parse(commad);

                if (price >= 0)
                {
                    totalPrice += price;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }

                commad = Console.ReadLine();
            }

            if (totalPrice != 0)
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {(totalPrice * 0.2):f2}$");
                Console.WriteLine("-----------");

                totalPrice *= 1.2;

                if (commad == "special")
                {
                    totalPrice *= 0.9;
                }
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
            else
            {
                Console.WriteLine("Invalid order!");
            }

        }
    }
}
