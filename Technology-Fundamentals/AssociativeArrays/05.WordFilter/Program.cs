using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string[] filteredWords = words.Where(x => (x.Length % 2 == 0)).ToArray();

            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
