using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            string pattern = @"@(?<planet>[A-Z][a-z]*)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldiers>\d+)";

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                int key = CalculateKey(message.ToLower());

                string decryptedMessage = DecryptMessageWithKey(message, key);

                MatchCollection info = Regex.Matches(decryptedMessage, pattern);

                foreach (Match match in info)
                {
                    string planetName = match.Groups["planet"].Value;
                    char attackType = char.Parse(match.Groups["attackType"].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        static string DecryptMessageWithKey(string message, int key)
        {
            StringBuilder result = new StringBuilder(message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                result.Append((char)(message[i] - key));
            }

            return result.ToString();
        }

        static int CalculateKey(string text)
        {
            int count = 0;

            foreach (char symbol in text)
            {
                if (symbol == 's' || symbol == 't' || symbol == 'a' || symbol == 'r')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
