using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            int delay = (int)(distance / 50) * 30;

            double totalTime = timeForMeter * distance + delay;

            if (totalTime >= worldRecord)
            {
                Console.WriteLine($"No! He was {(totalTime - worldRecord):f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
        }
    }
}
