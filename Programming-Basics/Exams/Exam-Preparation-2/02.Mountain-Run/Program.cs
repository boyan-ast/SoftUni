using System;

namespace _02.Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double totalTime = distance * timeForMeter;
            double delay = Math.Floor(distance / 50) * 30;

            totalTime += delay;

            if (totalTime < worldRecord)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {(totalTime-worldRecord):f2} seconds slower.");
            }           

        }
    }
}
