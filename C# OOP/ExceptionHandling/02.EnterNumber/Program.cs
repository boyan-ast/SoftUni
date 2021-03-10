using System;

namespace _02.EnterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                int number = default(int);

                try
                {
                    number = ReadNumber(1, 100);
                    numbers[i] = number;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException($"{number}", "The number is not in the range!");
            }


            return number;
        }
    }



}
