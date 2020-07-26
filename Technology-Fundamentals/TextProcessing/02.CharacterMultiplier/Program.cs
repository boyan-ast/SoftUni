using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split();

            string firstString = inputStrings[0];
            string secondString = inputStrings[1];

            int result = 0;

            if (firstString.Length >= secondString.Length)
            {
                result = CharacterMultiplier(secondString, firstString);
            }
            else
            {
                result = CharacterMultiplier(firstString, secondString);
            }
            Console.WriteLine(result);
        }

        private static int CharacterMultiplier(string smallerString, string biggerString)
        {
            int result = 0;

            for (int i = 0; i < smallerString.Length; i++)
            {
                result += smallerString[i] * biggerString[i];
            }

            for (int i = smallerString.Length; i < biggerString.Length; i++)
            {
                result += biggerString[i];
            }

            return result;
        }
    }
}
