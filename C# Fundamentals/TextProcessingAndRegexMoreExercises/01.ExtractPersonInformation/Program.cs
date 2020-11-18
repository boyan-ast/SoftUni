using System;
using System.Text.RegularExpressions;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string namePattern = @"(?<=@).+(?=\|)";
            string agePattern = @"(?<=\#).+(?=\*)";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match nameMatch = Regex.Match(input, namePattern);
                Match ageMatch = Regex.Match(input, agePattern);

                Console.WriteLine($"{nameMatch.Value} is {ageMatch.Value} years old.");
            }
        }
    }
}
