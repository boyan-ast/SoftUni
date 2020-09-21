using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairs; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                BigInteger firstNum = BigInteger.Parse(input[0]);
                BigInteger secondNum = BigInteger.Parse(input[1]);
                BigInteger result = 0;

                if (firstNum > secondNum)
                {
                    result = CalculeteSumOfDigits(firstNum);
                }
                else
                {
                    result = CalculeteSumOfDigits(secondNum);
                }

                Console.WriteLine(result);
            }
            
        }

        private static BigInteger CalculeteSumOfDigits(BigInteger number)
        {
            BigInteger sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return Math.Abs((int)sum);
        }
    }
}
