using System;

namespace _07.MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;

            for (int i = 0; i < numbers; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < minNumber)
                {
                    minNumber = num;
                }
            }

            Console.WriteLine(minNumber);
        }
    }
}
