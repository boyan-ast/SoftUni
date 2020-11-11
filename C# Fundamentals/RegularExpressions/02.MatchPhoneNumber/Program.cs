using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MatchCollection numbersMatches = Regex.Matches(input, @"(?<=^| )\+359([- ])2\1\d{3}\1\d{4}\b");

            string[] numbers = numbersMatches
                .Cast<Match>()
                .Select(x => x.Value)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
