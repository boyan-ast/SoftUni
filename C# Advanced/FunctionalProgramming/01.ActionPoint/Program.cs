using System;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> namePrinter = Print;

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            names.ToList().ForEach(namePrinter);
        }

        static void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
