using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string allWords = string.Empty;

            using (StreamReader wordsReader = new StreamReader("../../../words.txt"))
            {
                allWords = wordsReader.ReadToEnd().ToLower();
            }

            string[] words = allWords.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsCounter = new Dictionary<string, int>(words.Length);

            foreach (string word in words)
            {
                wordsCounter.Add(word, 0);

                using (StreamReader reader = new StreamReader("../../../text.txt"))
                {
                    string line = string.Empty;
                    string pattern = @$"\b{word}\b";

                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.ToLower();
                        int count = Regex.Matches(line, pattern).Count;
                        wordsCounter[word] += count;
                    }
                }
            }

            wordsCounter = wordsCounter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var kvp in wordsCounter)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
