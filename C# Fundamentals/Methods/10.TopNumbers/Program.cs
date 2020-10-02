using System;

namespace _10.TopNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                bool isTopNumber = CheckForTopNumbers(num);

                if (isTopNumber)
                {
                    Console.WriteLine(num);
                }
            }
        }

        private static bool CheckForTopNumbers(int num)
        {
            int sum = CalculateSumOfDigits(num);

            if (sum % 8 != 0)
            {
                return false;
            }

            bool hasOddDigit = CheckForOddDigit(num.ToString());

            if (!hasOddDigit)
            {
                return false;
            }

            return true;

        }

        private static bool CheckForOddDigit(string num)
        {
            const string OddDigits = "13579";

            for (int i = 0; i < num.Length; i++)
            {
                if (OddDigits.Contains(num[i].ToString()))
                {
                    return true;
                }
            }
                return false;
        }

        private static int CalculateSumOfDigits(int num)
        {
            int sum = 0;

            while (num != 0)
            {
                sum += num % 10;

                num /= 10;
            }

            return sum;
        }
    }
}
