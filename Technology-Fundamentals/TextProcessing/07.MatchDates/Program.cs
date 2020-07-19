using System;
using System.Text.RegularExpressions;

namespace _07.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Regex dates = new Regex(@"\b(?<day>[0-9]{2})(?<separator>[-|\.|\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})\b");

            MatchCollection correctDates = dates.Matches(inputString);

            foreach (Match match in correctDates)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");                
            }
        }
    }
}
