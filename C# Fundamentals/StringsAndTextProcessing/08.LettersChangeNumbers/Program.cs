using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            decimal totalSum = 0;

            foreach (string word in inputStrings)
            {
                char letterInFront = word[0];
                char letterAfter = word[word.Length - 1];
                string numberAsString = word.Substring(1, word.Length - 2);
                decimal number = decimal.Parse(numberAsString);

                decimal currentSum = 0;

                int letterInFrontPostion = CalculateLetterPosition(letterInFront);
                int letterAfterPosition = CalculateLetterPosition(letterAfter);

                if (char.IsUpper(letterInFront))
                {
                    currentSum = number * 1.0m / letterInFrontPostion;
                }
                else
                {
                    currentSum = number * letterInFrontPostion;
                }

                if (char.IsUpper(letterAfter))
                {
                    currentSum -= letterAfterPosition;
                }
                else
                {
                    currentSum += letterAfterPosition;
                }

                totalSum += currentSum;
            }

            Console.WriteLine($"{totalSum:f2}");

        }

        static int CalculateLetterPosition(char letter)
        {
            int position = char.ToLower(letter) - 96;
            return position;
        }
    }
}
