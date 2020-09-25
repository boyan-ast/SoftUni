using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> topIntegers = new List<int>();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int num = numbers[i];
                bool isTopInteger = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (num <= numbers[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    topIntegers.Add(num);
                }
            }

            topIntegers.Add(numbers[numbers.Length - 1]);

            Console.WriteLine(string.Join(" ", topIntegers));
        }
    }
}
