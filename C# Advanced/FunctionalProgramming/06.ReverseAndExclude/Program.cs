using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> isDivisible = n => n % divisor != 0;
            Action<int[]> reverser = ReverseArray;

            int[] numbers = input.Split().Select(int.Parse).Where(isDivisible).ToArray();
            reverser(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ReverseArray(int[] array)
        { 
            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }

        }
    }
}
