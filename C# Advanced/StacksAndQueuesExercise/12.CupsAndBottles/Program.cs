using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCapacity = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int wastedWater = 0;

            while (cupsCapacity.Any() && bottles.Any())
            {
                int currentCupCapacity = cupsCapacity.Peek();

                while ((currentCupCapacity > 0) && bottles.Any())
                {
                    int currentBottleVolume = bottles.Pop();
                    currentCupCapacity -= currentBottleVolume;
                }

                if (currentCupCapacity <= 0)
                {
                    cupsCapacity.Dequeue();
                    wastedWater += Math.Abs(currentCupCapacity);
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cupsCapacity.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
