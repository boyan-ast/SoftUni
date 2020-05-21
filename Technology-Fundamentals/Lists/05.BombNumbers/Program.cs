using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();

            int[] specialNumArray = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int specialNum = specialNumArray[0];
            int power = specialNumArray[1];

            while (true)
            {
                int index = numbers.IndexOf(specialNum);

                if (index == -1)
                {
                    break;
                }

                BombNumbers(numbers, specialNum, power, index);                
            }

            Console.WriteLine(numbers.Sum());
        }

        private static void BombNumbers(List<int> numbers, int specialNum, int power, int index)
        {
            if (power <= index)
            {
                numbers.RemoveRange((index - power), power);
                index = index - power;
            }
            else
            {
                numbers.RemoveRange(0, index);
                index = 0;
            }

            if (index + power >= numbers.Count)
            {
                numbers.RemoveRange(index, numbers.Count - index);
            }
            else
            {
                numbers.RemoveRange(index, power + 1);
            }
        }
    }
}
