using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            StringBuilder repeatedStrings = new StringBuilder();

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    repeatedStrings.Append(word);
                }
            }

            Console.WriteLine(repeatedStrings);
        }
    }
}
