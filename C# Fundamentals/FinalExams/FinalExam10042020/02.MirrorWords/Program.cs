using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@#])(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            if (!regex.IsMatch(text))
            {
                Console.WriteLine($"No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }

            MatchCollection wordPairs = regex.Matches(text);

            List<string> pairs = new List<string>();
            
            foreach (Match match in wordPairs)
            {
                string wordOne = match.Groups["wordOne"].Value;
                string wordTwo = match.Groups["wordTwo"].Value;

                char[] wordOneToArr = wordOne.ToCharArray();
                Array.Reverse(wordOneToArr);
                string wordOneReversed = new string(wordOneToArr);

                if (wordOneReversed.Equals(wordTwo))
                {
                    pairs.Add($"{wordOne} <=> {wordTwo}");
                }
            }

            Console.WriteLine($"{wordPairs.Count} word pairs found!");

            if (pairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", pairs));            
        }
    }
}
