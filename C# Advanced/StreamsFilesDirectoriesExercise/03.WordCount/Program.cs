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
            string[] words = File
                .ReadAllLines("../../../words.txt");

            words = words.Select(w => w.ToLower()).ToArray();

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string text = File.ReadAllText("../../../text.txt").ToLower();

            foreach (string word in words)
            {
                string pattern = @$"\b{word}\b";

                int count = Regex.Matches(text, pattern).Count;

                wordsCount.Add(word, count);
            }

            string[] resultArray = wordsCount.Select(x => $"{x.Key} - {x.Value}").ToArray();

            File.WriteAllLines("../../../actualResult.txt", resultArray);

            bool areEqual = File.ReadLines("../../../actualResult.txt")
                .SequenceEqual(File.ReadLines("../../../expectedResult.txt"));

            Console.WriteLine($"Are the two files equal? - {areEqual}");
        }
    }
}
