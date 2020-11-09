using System;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string word in bannedWords)
            {
                string asteriks = new string('*', word.Length);

                text = text.Replace(word, asteriks);
            }

            Console.WriteLine(text);
        }
    }
}
