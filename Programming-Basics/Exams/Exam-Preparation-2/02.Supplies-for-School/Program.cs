using System;

namespace _02.Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double cleaner = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pensPrice = pens * 5.80;
            double markersPrice = markers * 7.20;
            double cleanerPrice = cleaner * 1.20;

            double totalPrice = (pensPrice + markersPrice + cleanerPrice) * (100 - discount) / 100.00;

            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}
