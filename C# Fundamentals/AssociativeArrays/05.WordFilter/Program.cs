using System;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split()
                .Where(w => w.Length % 2 == 0);

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
