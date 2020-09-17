using System;
using System.Linq;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int[] numbers = new int[] { firstNum, secondNum, thirdNum };

            numbers = numbers.OrderByDescending(x => x).ToArray();

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
