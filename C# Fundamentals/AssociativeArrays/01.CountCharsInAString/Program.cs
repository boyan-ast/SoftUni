using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().Replace(" ", "");

            Dictionary<char, int> counts = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!counts.ContainsKey(text[i]))
                {
                    counts[text[i]] = 0;
                }

                counts[text[i]]++;
            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
