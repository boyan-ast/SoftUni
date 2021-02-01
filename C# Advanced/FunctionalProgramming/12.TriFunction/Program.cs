using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> sumChecker = IsSumLarger;
            Func<string[], Func<string, int, bool>, int, string> mainFunction = FirstSpecialNameFinder;

            Console.WriteLine(mainFunction(names, sumChecker, number));
        }

        static string FirstSpecialNameFinder(string[] names, Func<string, int, bool> sumChecker, int number)
        {
            string theName = string.Empty;

            foreach (string name in names)
            {
                if (sumChecker(name, number))
                {
                    return name;
                }
            }

            return null;
        }

        static bool IsSumLarger(string name, int n)
        {
            int sum = 0;

            foreach (char symbol in name)
            {
                sum += symbol;
            }

            if (sum >= n)
            {
                return true;
            }

            return false;
        }
    }
}
