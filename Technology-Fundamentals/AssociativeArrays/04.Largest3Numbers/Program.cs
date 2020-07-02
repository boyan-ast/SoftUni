using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Sort();
            numbers.Reverse();

            foreach (int num in numbers.Take(3))
            {
                Console.Write(num + " ");
            }
        }
    }
}
