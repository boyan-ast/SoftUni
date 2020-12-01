using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=([=\/]))(?<place>[A-Z][A-Za-z]{2,})(?=\1)";

            Regex rgx = new Regex(pattern);

            var matches = rgx.Matches(input);

            int points = matches.Select(x => x.Value).Sum(x => x.Length);

            Console.WriteLine("Destinations: " + string.Join(", ", matches));
            Console.WriteLine("Travel Points: {0}", points);
        }
    }
}
