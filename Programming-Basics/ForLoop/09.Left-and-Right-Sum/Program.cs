using System;

namespace _09.Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < numbers; i++)
            {
                firstSum += int.Parse(Console.ReadLine());
            }
            for (int j = 0; j < numbers; j++)
            {
                secondSum += int.Parse(Console.ReadLine());
            }

            if (firstSum == secondSum)
            {
                Console.WriteLine($"Yes, sum = {firstSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(firstSum - secondSum)}");
            }
        }
    }
}
