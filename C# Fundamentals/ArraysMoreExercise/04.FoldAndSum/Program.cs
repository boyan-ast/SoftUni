using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split().
                Select(int.Parse)
                .ToArray();

            int n = numbers.Length;

            int[] firstArray = new int[n / 2];
            int[] secondArray = new int[n / 2];

            for (int i = (n / 4) - 1; i >= 0; i--)
            {
                firstArray[(n / 4) - 1 - i] = numbers[i];
            }

            for (int j = n - 1; j >= (n / 4 + n / 2); j--)
            {
                firstArray[n - 1 - j + n / 4] = numbers[j];
            }

            for (int k = n / 4; k < n - n / 4; k++)
            {
                secondArray[k - n / 4] = numbers[k];
            }

            int[] resultArray = new int[n / 2];

            for (int i = 0; i < n / 2; i++)
            {
                resultArray[i] = firstArray[i] + secondArray[i];
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }
    }
}
