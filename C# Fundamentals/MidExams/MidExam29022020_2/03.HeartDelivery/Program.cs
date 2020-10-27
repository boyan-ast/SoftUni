using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> allHearts = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            string command = string.Empty;
            int index = 0;

            while ((command = Console.ReadLine()) != "Love!")
            {
                int length = int.Parse(command.Split()[1]);
                index += length;

                if (index > allHearts.Count - 1)
                {
                    index = 0;
                }

                SpreadLove(allHearts, index);
            }

            Console.WriteLine($"Cupid's last position was {index}.");

            if (allHearts.Sum() == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                int failedHouses = allHearts.Where(h => h != 0).Count();

                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }

        }

        static void SpreadLove(List<int> numbers, int index)
        {
            if (numbers[index] == 0)
            {
                Console.WriteLine($"Place {index} already had Valentine's day.");
            }
            else
            {
                numbers[index] -= 2;

                if (numbers[index] <= 0)
                {
                    numbers[index] = 0;

                    Console.WriteLine($"Place {index} has Valentine's day.");
                }
            }           
        }
    }
}
