using System;

namespace _01.Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entranceFee = double.Parse(Console.ReadLine());
            double sunbedPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double totalPrice = (people * entranceFee) + (Math.Ceiling(people / 2.0) * umbrellaPrice) + (Math.Ceiling(0.75 * people) * sunbedPrice);

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
