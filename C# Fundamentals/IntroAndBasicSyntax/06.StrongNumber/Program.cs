using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int digitsSum = 0;

            int currentNum = number;

            while (currentNum / 10 != 0)
            {
                int digit = currentNum % 10;

                digitsSum += FactorialCalculator(digit);

                currentNum /= 10;
            }

            digitsSum += FactorialCalculator(currentNum);

            if (digitsSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static int FactorialCalculator(int num)
        {
            int factorial = 1;

            for (int i = num; i >= 2; i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
