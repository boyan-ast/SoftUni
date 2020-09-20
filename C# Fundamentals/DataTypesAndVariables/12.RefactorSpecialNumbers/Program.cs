using System;
using System.Runtime.ExceptionServices;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            for (int num = 1; num <= numbers; num++)
            {
                int sum = 0;
                int temp = num;

                while (temp > 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }

                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {isSpecial}");
            }
        }
    }
}
