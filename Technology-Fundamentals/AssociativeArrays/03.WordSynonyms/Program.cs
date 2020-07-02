using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsNumber = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> wordsSynonyms = new Dictionary<string, List<string>>();

            DictionaryFiller(wordsSynonyms, wordsNumber);
            PrintTheSynonyms(wordsSynonyms);            
        }

        private static void PrintTheSynonyms(Dictionary<string, List<string>> words)
        {
            foreach (var kvp in words)
            {
                Console.WriteLine(kvp.Key + " - " + string.Join(", ", kvp.Value));
            }
        }

        private static void DictionaryFiller(Dictionary<string, List<string>> words, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                }

                words[word].Add(synonym);
            }
        }
    }
}
