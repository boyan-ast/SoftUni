using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;

            foreach (string element in input)
            {
                char letterInFront = element[0];
                char letterAfter = element[element.Length - 1];

                decimal number = decimal.Parse(element.Substring(1, element.Length - 2));
                decimal result = 0;

                int firstLetterPosition = FindLetterPosition(char.ToLower(letterInFront));

                if (char.IsUpper(letterInFront))
                {
                    result = (number / firstLetterPosition);
                }
                else
                {
                    result = number * firstLetterPosition;
                }

                int secondLetterPosition = FindLetterPosition(char.ToLower(letterAfter));

                if (char.IsUpper(letterAfter))
                {
                    result -= secondLetterPosition;
                }
                else
                {
                    result += secondLetterPosition;
                }

                sum += result;
            }

            Console.WriteLine($"{sum:f2}");
        }

        static int FindLetterPosition(char letter)
        {
            int position = letter - 96;

            return position;
        }
    }
}
