using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string input = Console.ReadLine().ToLower();
            int index = input.IndexOf(word);

            while (index != -1)
            {
                input = input.Remove(index, word.Length);
                index = input.IndexOf(word);
            }

            Console.WriteLine(input);
        }
    }
}
