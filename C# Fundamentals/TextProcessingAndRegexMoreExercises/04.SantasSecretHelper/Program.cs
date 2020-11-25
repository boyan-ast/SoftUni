using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> goodKids = new List<string>();

            int key = int.Parse(Console.ReadLine());
            string pattern = @"(?<=@)(?<name>[A-Za-z]+)[^@\-!:>]+!(?<behavior>[GN])!";
            Regex rgx = new Regex(pattern);

            string message = string.Empty;

            while ((message = Console.ReadLine()) != "end")
            {
                string decryptedMessage = DecryptTheMessage(message, key);

                Match match = rgx.Match(decryptedMessage);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    char behavior = char.Parse(match.Groups["behavior"].Value);

                    if (behavior == 'G')
                    {
                        goodKids.Add(name);
                    }
                }
            }

            foreach (string kid in goodKids)
            {
                Console.WriteLine(kid);
            }
        }

        private static string DecryptTheMessage(string message, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder(message.Length);

            for (int i = 0; i < message.Length; i++)
            {
                char newSymbol = (char)(message[i] - key);
                decryptedMessage.Append(newSymbol.ToString());
            }

            return decryptedMessage.ToString();
        }
    }
}
