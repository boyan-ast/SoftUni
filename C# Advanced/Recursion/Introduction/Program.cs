using System;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 3, 7, 8 };

            int sum = Sum(array, 0);

            Console.WriteLine(sum);
        }

        static int Sum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            Console.WriteLine("Before recursion");
            int currentSum = array[index] + Sum(array, index + 1);
            Console.WriteLine(currentSum);
            Console.WriteLine("After recursion");

            return currentSum;
        }

        static void Print(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(n);
            Console.WriteLine("Hello Recursion!");
            Print(n - 1);
        }
    }
}
