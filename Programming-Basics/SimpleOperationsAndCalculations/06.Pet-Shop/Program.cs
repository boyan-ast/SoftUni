using System;

namespace _06.Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            double totalSum = dogs * 2.5 + otherAnimals * 4;

            Console.WriteLine($"{totalSum:f2} lv.");
        }
    }
}
