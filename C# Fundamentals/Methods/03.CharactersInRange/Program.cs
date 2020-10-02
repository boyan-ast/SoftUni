using System;
using System.Text;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            if (start < end)
            {
                PrintCharsInRange(start, end);
            }
            else
            {
                PrintCharsInRange(end, start);
            }
            
        }

        private static void PrintCharsInRange(char start, char end)
        {
            StringBuilder chars = new StringBuilder();

            for (char i = (char)(start + 1); i < end; i++)
            {
                chars.Append((i+" ").ToString());
            }

            Console.WriteLine(chars.ToString().Trim());
        }
    }
}
