using System;

namespace _05.Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            foreach (char character in text)
            {
                Console.WriteLine(character);
            }
        }
    }
}
