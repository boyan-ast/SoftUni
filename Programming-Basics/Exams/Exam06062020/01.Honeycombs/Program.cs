using System;

namespace _01.Honeycombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBees = int.Parse(Console.ReadLine());
            int numberOfFlowers = int.Parse(Console.ReadLine());

            double honeyVolume = numberOfBees * numberOfFlowers * 0.21;
            int numberOfHoneycombs = (int)(honeyVolume / 100);
            double honeyLeft = honeyVolume - numberOfHoneycombs * 100;

            Console.WriteLine($"{numberOfHoneycombs} honeycombs filled.");
            Console.WriteLine($"{honeyLeft:f2} grams of honey left.");
        }
    }
}
