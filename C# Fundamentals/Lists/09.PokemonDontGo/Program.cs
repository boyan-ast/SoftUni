using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            int sum = 0;

            while (numbers.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                int element = 0;

                if (index >= 0 && index < numbers.Count)
                {
                    element = numbers[index];
                    numbers.RemoveAt(index);
                    IncreaseAndDecreaseNumbers(numbers, element);
                }
                else if (index < 0)
                {
                    element = numbers[0];
                    numbers[0] = numbers[numbers.Count - 1];
                    IncreaseAndDecreaseNumbers(numbers, element);
                }
                else if (index >= numbers.Count)
                {
                    element = numbers[numbers.Count - 1];
                    numbers[numbers.Count - 1] = numbers[0];
                    IncreaseAndDecreaseNumbers(numbers, element);
                }

                sum += element;
            }

            Console.WriteLine(sum);
        }

        private static void IncreaseAndDecreaseNumbers(List<int> numbers, int element)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= element)
                {
                    numbers[i] += element;
                }
                else
                {
                    numbers[i] -= element;
                }
            }
        }
    }
}
