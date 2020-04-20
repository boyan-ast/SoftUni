using System;
using System.Linq;

namespace _08.Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int leftNum = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int rightNum = numbers[j];

                    if (leftNum + rightNum == magicNumber)
                    {
                        Console.WriteLine($"{leftNum} {rightNum}");
                        break;
                    }
                }
            }
        }
    }
}
