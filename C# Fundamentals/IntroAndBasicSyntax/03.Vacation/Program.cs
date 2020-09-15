using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double singlePrice = 0;

            if (day == "Friday")
            {
                if (groupType == "Students")
                {
                    singlePrice = 8.45;
                }
                else if (groupType == "Business")
                {
                    singlePrice = 10.90;
                }
                else if (groupType == "Regular")
                {
                    singlePrice = 15;
                }
            }
            else if (day == "Saturday")
            {
                if (groupType == "Students")
                {
                    singlePrice = 9.80;
                }
                else if (groupType == "Business")
                {
                    singlePrice = 15.60;
                }
                else if (groupType == "Regular")
                {
                    singlePrice = 20;
                }
            }
            else if (day == "Sunday")
            {
                if (groupType == "Students")
                {
                    singlePrice = 10.46;
                }
                else if (groupType == "Business")
                {
                    singlePrice = 16;
                }
                else if (groupType == "Regular")
                {
                    singlePrice = 22.50;
                }
            }

            double totalPrice = singlePrice * people;

            if (groupType == "Students" && people >= 30)
            {
                totalPrice *= 0.85;
            }
            else if (groupType == "Business" && people >= 100)
            {
                totalPrice = singlePrice * (people - 10);
            }
            else if (groupType == "Regular" && people >= 10 && people <= 20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
