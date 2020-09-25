using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] resultArray = new int[2, n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int leftNum = input[0];
                int rightNum = input[1];

                if (i % 2 == 0)
                {
                    resultArray[0, i] = leftNum;
                    resultArray[1, i] = rightNum;
                }
                else
                {
                    resultArray[0, i] = rightNum;
                    resultArray[1, i] = leftNum;
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(resultArray[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
