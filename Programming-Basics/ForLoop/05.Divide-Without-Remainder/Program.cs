using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> divisibleNumbers = new Dictionary<int, int>
            {
                { 2, 0 },
                { 3, 0 },
                { 4, 0 }
            };

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    divisibleNumbers[2]++;
                }
                if (number % 3 == 0)
                {
                    divisibleNumbers[3]++;
                }
                if (number % 4 == 0)
                {
                    divisibleNumbers[4]++;
                }
            }

            for (int j = 2; j <= 4; j++)
            {
                Console.WriteLine($"{(divisibleNumbers[j]*1.0/n * 100):f2}%");
            }
            
        }
    }
}
