using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex numbers = new Regex(@"(?<=^| )\+359(?<separator>[ |-])[2]\k<separator>[\d]{3}\k<separator>[\d]{4}\b");
            List<string> correctNumbers = new List<string>();

            foreach (Match match in numbers.Matches(input))
            {
                correctNumbers.Add(match.ToString());
            }

            Console.WriteLine(string.Join(", ", correctNumbers));
        }
    }
}
