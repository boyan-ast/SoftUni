using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] instructions = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                FollowTheInstructions(words, instructions);
            }

            Console.WriteLine(string.Join(" ", words));
        }
        public static void FollowTheInstructions(List<string> words, string[] tokens)
        {
            string action = tokens[0];

            if (action == "Delete")
            {
                int index = int.Parse(tokens[1]);
                // -1 or 0
                if (index >= -1 && index < words.Count - 1)
                {
                    words.RemoveAt(index + 1);
                }
            }
            else if (action == "Swap")
            {
                string firstWord = tokens[1];
                string secondWord = tokens[2];

                int firstIndex = words.IndexOf(firstWord);
                int secondIndex = words.IndexOf(secondWord);

                if (firstIndex != -1 && secondIndex != -1)
                {
                    words[firstIndex] = secondWord;
                    words[secondIndex] = firstWord;
                }
            }
            else if (action == "Put")
            {
                string word = tokens[1];
                int index = int.Parse(tokens[2]);

                // > 0 or >= 0, < words.Count or <= words.Count

                if (index > 0 && index <= words.Count)
                {
                    words.Insert(index - 1, word);
                }
            }
            else if (action == "Sort")
            {
                words.Sort();
                words.Reverse();
            }
            else if (action == "Replace")
            {
                string firstWord = tokens[1];
                string secondWord = tokens[2];

                int secondIndex = words.IndexOf(secondWord);

                if (secondIndex != -1)
                {
                    words[secondIndex] = firstWord;
                }
            }
        }
    }
}
