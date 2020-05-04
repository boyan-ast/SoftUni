using System;

namespace _10.Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int evensSum = 0;
            int oddsSum = 0;

            for (int i = 1; i <= numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evensSum += number;
                }
                else
                {
                    oddsSum += number;
                }
            }

            if (evensSum == oddsSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + evensSum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + Math.Abs(evensSum - oddsSum));
            }
        }
    }
}
