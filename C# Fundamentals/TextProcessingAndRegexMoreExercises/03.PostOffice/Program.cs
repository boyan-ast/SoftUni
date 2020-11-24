using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string capitalLettersPattern = @"([#$%*&])(?<letters>[A-Z]+)\1";
            char[] capitalLetters = Regex.Match(firstPart, capitalLettersPattern).Groups["letters"].Value.ToCharArray();

            for (int i = 0; i < capitalLetters.Length; i++)
            {
                int asciiCode = capitalLetters[i];

                string asciiCodesPattern = $@"([{asciiCode}]{{2}}):(?<length>[\d]{{2}})";

                Match asciiMatch = Regex.Match(secondPart, asciiCodesPattern);
                int length = int.Parse(asciiMatch.Groups["length"].Value);

                string wordPattern = $@"(?<=\s|^)({capitalLetters[i]})[\S]{{{length}}}(?=\s|$)";

                Match wordMatch = Regex.Match(thirdPart, wordPattern);

                if (wordMatch.Value.Length >= 1 && wordMatch.Value.Length <= 20)
                {
                    Console.WriteLine(wordMatch.Value);
                }
            }
        }
    }
}
