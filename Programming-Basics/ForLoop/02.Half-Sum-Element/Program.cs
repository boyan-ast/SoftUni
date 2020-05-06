using System;

namespace _02.Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;

                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            sum -= maxNumber;

            if (maxNumber == sum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNumber}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNumber - sum)}");
            }
        }
    }
}
