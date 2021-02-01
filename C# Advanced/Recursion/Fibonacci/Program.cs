using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[] numbers = new long[n + 1];
            numbers[1] = 1;
            numbers[2] = 1;

            long result = Fibonacci(n, numbers);

            Console.WriteLine(result);
        }

        static long Fibonacci(int n, long[] numbers)
        {
            if (numbers[n] == 0)
            {
                long first = Fibonacci(n - 1, numbers);
                long second = Fibonacci(n - 2, numbers);
                numbers[n] = first + second;
            }

            return numbers[n];
        }
    }
}
