using System;

namespace _02.VowelsCount
{
    class Program
    {
        const string Vowels = "aeiou"; 

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int vowels = VowelsCounter(text.ToLower());
            Console.WriteLine(vowels);
        }
        private static int VowelsCounter(string text)
        {
            int counter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Vowels.Contains(text[i].ToString()))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
