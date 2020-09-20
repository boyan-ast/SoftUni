using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                bool special = CheckNumber(num);

                Console.WriteLine($"{num} -> {special}");
            }
        }

        private static bool CheckNumber(int num)
        {
            int digitsSum = 0;

            while(num != 0)
            {
                digitsSum += num % 10;
                num /= 10;
            }

            if (digitsSum == 5 || digitsSum == 7 || digitsSum == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
