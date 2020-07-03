using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().Where(x => x != ' ').ToArray();

            Dictionary<char, int> charsCounter = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!charsCounter.ContainsKey(text[i]))
                {
                    charsCounter[text[i]] = 0;
                }

                charsCounter[text[i]]++;
            }

            foreach (var kvp in charsCounter)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
