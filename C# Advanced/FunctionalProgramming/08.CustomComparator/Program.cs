using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> isBigger = IsFirstBigger;

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, IsFirstBigger);

            Console.WriteLine(string.Join(" ", numbers));            
        }

        static int IsFirstBigger(int firstNum, int secondNum)
        {
            if (firstNum % 2 == 0 && secondNum % 2 != 0)
            {
                return -1;
            }
            else if (firstNum % 2 != 0 && secondNum % 2 == 0)
            {
                return 1;
            }
            else
            {
                if (firstNum > secondNum)
                {
                    return 1;
                }

                return -1;
            }
        }
    }
}
