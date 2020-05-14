using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            int primesSum = 0;
            int nonPrimesSum = 0;

            while ((command = Console.ReadLine()) != "stop")
            {
                int number = int.Parse(command);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool isPrime = CheckIfIsPrimeOrNot(number);

                if (isPrime)
                {
                    primesSum += number;
                }
                else
                {
                    nonPrimesSum += number;
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primesSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimesSum}");
        }

        private static bool CheckIfIsPrimeOrNot(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
