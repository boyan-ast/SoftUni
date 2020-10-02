using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double result = (double)Factorial(firstNum) / Factorial(secondNum);

            Console.WriteLine($"{result:f2}");
        }

        private static long Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
