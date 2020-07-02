using System;
using System.Collections.Generic;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToLower().Split();
            Dictionary<string, int> occurrences = new Dictionary<string, int>();


            foreach (string word in words)
            {
                if (!occurrences.ContainsKey(word))
                {
                    occurrences[word] = 0;
                }

                occurrences[word]++;
            }

            foreach (var kvp in occurrences)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}
