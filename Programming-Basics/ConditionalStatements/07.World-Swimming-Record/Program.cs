using System;

namespace _07.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double totalTime = timePerMeter * distance;
            double delays = Math.Floor(distance / 15);

            totalTime += delays * 12.5;

            if (totalTime < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - worldRecord):f2} seconds slower.");
            }
        }
    }
}
