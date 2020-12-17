using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!G!";
            Regex rgx = new Regex(pattern);

            List<string> goodKids = new List<string>();

            string encryptedMessage = string.Empty;

            while ((encryptedMessage = Console.ReadLine()) != "end")
            {
                StringBuilder message = new StringBuilder(encryptedMessage.Length);

                for (int i = 0; i < encryptedMessage.Length; i++)
                {
                    message.Append((char)(encryptedMessage[i] - key));
                }

                if (rgx.Match(message.ToString()).Success)
                {
                    goodKids.Add($"{rgx.Match(message.ToString()).Groups["name"]}");
                }
            }

            foreach (string kid in goodKids)
            {
                Console.WriteLine(kid);
            }
                    
        }
    }
}
