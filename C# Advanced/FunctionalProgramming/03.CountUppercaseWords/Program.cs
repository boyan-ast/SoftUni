using System;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> upperWords = word =>
            {
                if (Char.IsUpper(word[0]))
                {
                    Console.WriteLine(word);
                }
            };

            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Array.ForEach(words, upperWords);
        }
    }
}
