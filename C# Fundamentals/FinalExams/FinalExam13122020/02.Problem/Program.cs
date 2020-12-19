using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^([$%])(?<tag>[A-Z][a-z]{2,})\1: \[(?<first>\d+)\]\|\[(?<second>\d+)\]\|\[(?<third>\d+)\]\|$$";

            for (int i = 0; i < n; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), pattern);

                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;
                    char firstSymbol = (char)int.Parse(match.Groups["first"].Value);
                    char secondSymbol = (char)int.Parse(match.Groups["second"].Value);
                    char thirdSymbol = (char)int.Parse(match.Groups["third"].Value);

                    Console.WriteLine($"{tag}: {firstSymbol}{secondSymbol}{thirdSymbol}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
