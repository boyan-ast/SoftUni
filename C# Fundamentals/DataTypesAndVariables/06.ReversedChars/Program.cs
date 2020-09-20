using System;
using System.Linq;


namespace _06.ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            char[] symbols = new char[] { firstChar, secondChar, thirdChar };
            char[] reversedArray = symbols.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", reversedArray));
        }
    }
}
