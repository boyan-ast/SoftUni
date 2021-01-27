using System;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, bool> filter = n => n.Length <= length;

            PrintFilteredResult(names, filter);
        }


        private static void PrintFilteredResult(string[] names, Func<string, bool> condition)
        {
            foreach (string name in names)
            {
                if (condition(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
