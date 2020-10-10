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
                .Select(int.Parse)
                .ToList();

            int[] numAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int specialNumber = numAndPower[0];
            int power = numAndPower[1];

            int specialIndex = numbers.IndexOf(specialNumber);

            while (specialIndex != -1)
            {
                for (int i = specialIndex; i >= (Math.Max((specialIndex - power), 0)); i--)
                {
                    numbers[i] = 0;
                }

                for (int j = specialIndex + 1; j <= Math.Min((specialIndex + power), numbers.Count - 1); j++)
                {
                    numbers[j] = 0;
                }

                specialIndex = numbers.IndexOf(specialNumber);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
