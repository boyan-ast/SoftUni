using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringToRemove = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int startIndex = text.IndexOf(stringToRemove);

            while (startIndex != -1)
            {
                text = text.Remove(startIndex, stringToRemove.Length);

                startIndex = text.IndexOf(stringToRemove);
            }

            Console.WriteLine(text);
        }
    }
}
