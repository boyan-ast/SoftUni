using System;

namespace _01.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int diluent = int.Parse(Console.ReadLine());
            int workingHours = int.Parse(Console.ReadLine());

            double totalMaterialsPrice = (nylon + 2) * 1.50 + (paint * 1.1) * 14.50 + diluent * 5 + 0.4;
            double workersPayment = totalMaterialsPrice * 0.3 * workingHours;

            double totalPrice = totalMaterialsPrice + workersPayment;

            Console.WriteLine($"Total expenses: {totalPrice:f2} lv.");
        }
    }
}
