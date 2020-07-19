using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder outputString = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                int wordLength = words[i].Length;

                for (int j = 0; j < wordLength; j++)
                {
                    outputString.Append(words[i]);
                }
            }

            Console.WriteLine(outputString);
        }
    }
}
