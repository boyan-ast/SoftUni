using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = numbers.Where(x => x % 2 == 0).Sum();
            int oddSum = numbers.Where(x => x % 2 == 1).Sum();

            Console.WriteLine(evenSum - oddSum);
        }
    }
}
