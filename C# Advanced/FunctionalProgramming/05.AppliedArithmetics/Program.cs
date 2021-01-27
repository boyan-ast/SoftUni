using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    Func<int, int> calculate = Calculations(command);
                    numbers = numbers.Select(calculate).ToArray();
                }
            }
        }

        private static Func<int, int> Calculations(string action)
        {
            switch (action)
            {
                case "add": return n => n + 1;
                case "multiply": return n => n * 2;
                case "subtract": return n => n - 1;
                default: return null;
            }
        }
    }
}
