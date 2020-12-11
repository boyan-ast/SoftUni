using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputParts = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string firstPart = inputParts[0];
            string secondPart = inputParts[1];
            string thirdPart = inputParts[2];

            string capitalLettersPattern = @"(?<=([#$%*&]))[A-Z]+(?=\1)";
            string capitalLetters = Regex.Match(firstPart, capitalLettersPattern).Value;

            string codesPattern = @"(?<letterCode>\d{2}):(?<length>\d{2})";
            MatchCollection allCodesMatches = Regex.Matches(secondPart, codesPattern);

            StringBuilder validWords = new StringBuilder();

            foreach (char letter in capitalLetters)
            {
                foreach (Match code in allCodesMatches)
                {
                    char capitalLetterFromCode = (char)int.Parse(code.Groups["letterCode"].Value);
                    if (letter == capitalLetterFromCode)
                    {
                        int length = int.Parse(code.Groups["length"].Value);

                        string wordPattern = $@"(?<= |^){letter}\S{{{length}}}(?= |$)";

                        Match wordMatch = Regex.Match(thirdPart, wordPattern);

                        if (wordMatch.Success)
                        {
                            string word = wordMatch.Value;

                            if (!validWords.ToString().Contains(word))
                            {
                                validWords.AppendLine(word);
                            }                            
                        }
                    }
                }                
            }

            string result = validWords.ToString().Trim();

            Console.WriteLine(result);
        }
    }
}
