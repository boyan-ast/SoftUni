using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.OddTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if ((numbers[i] ^ numbers[j]) == 0)
                    {
                        numbers[i] = 0;
                        numbers[j] = 0;
                        break;
                    }
                }                
            }

            int result = numbers.First(x => x != 0);
            Console.WriteLine(result);
        }
    }
}
