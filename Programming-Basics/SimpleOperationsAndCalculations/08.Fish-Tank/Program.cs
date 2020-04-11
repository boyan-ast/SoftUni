using System;

namespace _08.Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double othersPercent = double.Parse(Console.ReadLine());

            double volumeInLiters = length * 0.1 * width * 0.1 * height * 0.1;

            volumeInLiters *= (100 - othersPercent) / 100;

            Console.WriteLine($"{volumeInLiters:f3}");

        }
    }
}
