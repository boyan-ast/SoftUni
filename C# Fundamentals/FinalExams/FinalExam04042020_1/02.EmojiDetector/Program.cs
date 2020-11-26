using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string digitPattern = @"[\d]";

            int coolValue = 1;

            var allDigits = Regex.Matches(text, digitPattern);

            foreach (Match match in allDigits)
            {
                coolValue *= int.Parse(match.Value);
            }

            string emojiPattern = @"((\:\:)|(\*\*))(?<name>[A-Z][a-z]{2,})\1";

            MatchCollection allEmojis = Regex.Matches(text, emojiPattern);

            List<string> coolEmojis = new List<string>();
            int count = 0;

            foreach (Match match in allEmojis)
            {
                count++;

                int sum = 0;
                string emoji = match.Groups["name"].Value;

                for (int i = 0; i < emoji.Length; i++)
                {
                    sum += emoji[i];
                }

                if (sum >= coolValue)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolValue}");
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");

            foreach (string emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
