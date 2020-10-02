using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            FindMiddleChars(input);
        }

        private static void FindMiddleChars(string text)
        {
            string result = string.Empty;

            if (text.Length % 2 == 0)
            {
                result = text.Substring((text.Length / 2 - 1), 2);
            }
            else
            {
                result = text[text.Length / 2].ToString();
            }

            Console.WriteLine(result);
        }
    }
}
