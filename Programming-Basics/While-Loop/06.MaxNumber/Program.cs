using System;

namespace _06.MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > maxNumber)
                {
                    maxNumber = num;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
