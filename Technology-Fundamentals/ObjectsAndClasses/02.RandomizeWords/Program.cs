using System;

namespace _02.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(" ");

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                string temp = words[i];
                int randomPosition = rnd.Next(0, words.Length);
                words[i] = words[randomPosition];
                words[randomPosition] = temp;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
