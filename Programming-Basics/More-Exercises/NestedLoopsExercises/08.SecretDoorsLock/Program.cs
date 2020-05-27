using System;
using System.Collections.Generic;

namespace _08.SecretDoorsLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigitMaxValue = int.Parse(Console.ReadLine());
            int secondDigitMaxValue = int.Parse(Console.ReadLine());
            int thirdDigitMaxValue = int.Parse(Console.ReadLine());

            List<int> secondDigitOptions = new List<int> { 2, 3, 5, 7 };

            for (int i = 2; i <= firstDigitMaxValue; i+=2)
            {
                for (int j = 2; j <= secondDigitMaxValue; j++)
                {
                    for (int k = 2; k <= thirdDigitMaxValue; k+=2)
                    {
                        if (secondDigitOptions.Contains(j))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
