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

            int sum = 0;

            for (int i = 0; i < Math.Max(firstString.Length, secondString.Length); i++)
            {
                if (i < firstString.Length && i < secondString.Length)
                {
                    sum += firstString[i] * secondString[i];
                }
                else if (i >= firstString.Length)
                {
                    sum += secondString[i];
                }
                else
                {
                    sum += firstString[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
