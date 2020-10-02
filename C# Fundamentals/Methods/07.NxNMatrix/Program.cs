using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintMatrix(number);
        }

        private static void PrintMatrix(int num)
        {
            int[] singleLine = new int[num];

            for (int i = 0; i < num; i++)
            {
                singleLine[i] = num;
            }

            for (int j = 0; j < num; j++)
            {
                Console.WriteLine(string.Join(" ", singleLine));
            }
        }
    }
}
