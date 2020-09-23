using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split().Reverse().ToArray();

            Console.WriteLine(string.Join(' ',inputStrings));
        }
    }
}
