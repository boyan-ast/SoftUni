using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            while (input != "Stop")
            {
                int number = int.Parse(input);
                sum += number;
                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}
