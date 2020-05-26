using System;
using System.Collections.Generic;

namespace _01.UniquePinCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDigitMaxValue = int.Parse(Console.ReadLine());
            int secondDigitMaxValue = int.Parse(Console.ReadLine());
            int thirdDigitMaxValue = int.Parse(Console.ReadLine());

            List<int> primeNumbers = new List<int>{ 2, 3, 5, 7 };

            for (int i = 2; i <= firstDigitMaxValue; i+=2)
            {
                for (int j = 0; j < primeNumbers.Count; j++)
                {
                    if (primeNumbers[j] > secondDigitMaxValue)
                    {
                        break;
                    }
                    for (int k = 2; k <= thirdDigitMaxValue; k+=2)
                    {
                        Console.WriteLine($"{i} {primeNumbers[j]} {k}");
                    }
                }
            }           

        }       
    }
}
