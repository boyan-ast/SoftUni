using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            FindTheSmallestNumber(firstNum, secondNum, thirdNum);
        }

        private static void FindTheSmallestNumber(int a, int b, int c)
        {
            if (a <= b)
            {
                if (a <= c)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine(c);
                }
            }
            else if (a > b)
            {
                if (b <= c)
                {
                    Console.WriteLine(b);
                }
                else
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
