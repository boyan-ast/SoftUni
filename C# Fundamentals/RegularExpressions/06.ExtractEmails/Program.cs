using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s)[A-Za-z0-9]+([\.\-_]?[A-Za-z0-9]+)*@(?<host>[A-Za-z]+(\-?[A-Za-z]+)*\.[A-Za-z]+(\-?[A-Za-z]+)*(\.?[A-Za-z]+(\-?[A-Za-z])*)*)";

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
