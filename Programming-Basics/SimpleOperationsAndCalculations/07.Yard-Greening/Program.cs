using System;

namespace _07.Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double yardArea = double.Parse(Console.ReadLine());

            double totalPrice = yardArea * 7.61;
            double discount = totalPrice * 0.18;

            double finalPrice = totalPrice - discount;

            Console.WriteLine($"The final price is: {finalPrice:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");

        }
    }
}
