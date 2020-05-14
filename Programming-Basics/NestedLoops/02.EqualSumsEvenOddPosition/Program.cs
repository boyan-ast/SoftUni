using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            PrintMagicNumbers(start, end);
        }

        private static void PrintMagicNumbers(int start, int end)
        {
            for (int number = start; number <= end; number++)
            {
                string stringNumber = number.ToString();
                int evensSum = 0;
                int oddsSum = 0;

                for (int j = 0; j < stringNumber.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        oddsSum += int.Parse(stringNumber[j].ToString());
                    }
                    else
                    {
                        evensSum += int.Parse(stringNumber[j].ToString());
                    }
                }

                if (oddsSum == evensSum)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
