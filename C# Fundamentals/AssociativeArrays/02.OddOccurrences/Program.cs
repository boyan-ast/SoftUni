using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allWords = Console.ReadLine()
                .ToLower()
                .Split()
                .ToList();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in allWords)
            {
                if (!counts.ContainsKey(word))
                {
                    counts.Add(word, 0);
                }

                counts[word]++;
            }

            List<string> oddCounts = counts
                .Where(x => x.Value % 2 != 0)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine(string.Join(" ", oddCounts));
        }
    }
}
