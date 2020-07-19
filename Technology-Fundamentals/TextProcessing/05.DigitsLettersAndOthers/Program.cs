using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _05.DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Regex digitsPattern = new Regex(@"[0-9]+");
            Regex lettersPattern = new Regex(@"[A-Za-z]+");
            Regex othersPattern = new Regex(@"\W");

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder otherSymbols = new StringBuilder();

            MatchCollection allDigits = digitsPattern.Matches(inputString);
            MatchCollection allLetters = lettersPattern.Matches(inputString);
            MatchCollection allOthers = othersPattern.Matches(inputString);

            foreach (Match match in allDigits)
            {
                digits.Append(match);
            }
            foreach (Match match in allLetters)
            {
                letters.Append(match);
            }
            foreach (Match match in allOthers)
            {
                otherSymbols.Append(match);
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherSymbols);
        }
    }
}
