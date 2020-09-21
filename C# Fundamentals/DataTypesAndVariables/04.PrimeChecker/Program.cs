using System;

namespace _04.PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int num = 2; num <= number; num++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(num); j++)
                {
                    if (num % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", num, isPrime.ToString().ToLower());
            }

        }
    }
}
