using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=^| )(?<day>\d{2})(?<separator>.)(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})";
            MatchCollection datesMatches = Regex.Matches(input, pattern);

            foreach (Match date in datesMatches)
            {
                Console.WriteLine($"Day: {date.Groups["day"].Value}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }

        }
    }
}
