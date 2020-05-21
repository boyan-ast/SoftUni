using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(x => double.Parse(x))
                .ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i+1])
                {
                    numbers[i + 1] += numbers[i];
                    numbers.RemoveAt(i);

                    if (i < 1)
                    {
                        i--;
                    }
                    else
                    {
                        i -= 2;
                    }                    
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
