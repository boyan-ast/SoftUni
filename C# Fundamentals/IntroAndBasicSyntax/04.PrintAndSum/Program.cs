using System;

namespace _04.PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int num = start; num <= end; num++)
            {
                Console.Write($"{num} ");
                sum += num;
            }

            Console.WriteLine();

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
