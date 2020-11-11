using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+");

            MatchCollection fullNames = regex.Matches(input);

            foreach (Match name in fullNames)
            {
                Console.Write($"{name.Value} ");
            }
        }
    }
}
