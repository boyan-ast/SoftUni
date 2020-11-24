using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder rageMessage = new StringBuilder();

            string input = Console.ReadLine();

            string symbolsPattern = @"([\D]+)";
            string digitsPattern = @"([\d]+)";

            var stringsMatches = Regex.Matches(input, symbolsPattern);
            var digitsMatches = Regex.Matches(input, digitsPattern);

            List<string> allStrings = stringsMatches.Select(x => x.Value.ToUpper()).ToList();
            List<int> allDigits = digitsMatches.Select(x => int.Parse(x.Value)).ToList();

            for (int i = 0; i < allDigits.Count; i++)
            {
                for (int j = 0; j < allDigits[i]; j++)
                {
                    rageMessage.Append(allStrings[i]);
                }
            }
            
            Console.WriteLine($"Unique symbols used: {rageMessage.ToString().Distinct().Count()}");
            Console.WriteLine(rageMessage);
        }
    }
}
