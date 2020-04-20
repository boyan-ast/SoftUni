using System;
using System.Linq;

namespace _03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputArrays = int.Parse(Console.ReadLine());

            int[] firstArray = new int[numberOfInputArrays];
            int[] secondArray = new int[numberOfInputArrays];

            for (int i = 0; i < numberOfInputArrays; i++)
            {
                int[] currentArray = Console.ReadLine()
                    .Split()
                    .Select(x => int.Parse(x))
                    .ToArray();

                int leftNumber = currentArray[0];
                int rightNumber = currentArray[1];

                if (i % 2 == 0)
                {
                    firstArray[i] = leftNumber;
                    secondArray[i] = rightNumber;
                }
                else
                {
                    firstArray[i] = rightNumber;
                    secondArray[i] = leftNumber;
                }
            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
