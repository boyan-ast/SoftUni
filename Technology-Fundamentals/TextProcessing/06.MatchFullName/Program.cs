using System;
using System.Text.RegularExpressions;

namespace _06.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Regex fullNames = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            MatchCollection allMatches = fullNames.Matches(inputString);

            foreach (Match match in allMatches)
            {
                Console.Write($"{match} ");
            }
        }
    }
}
