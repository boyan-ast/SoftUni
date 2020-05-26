using System;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char forbiddenLetter = char.Parse(Console.ReadLine());
            int combinations = 0;

            for (char i = startLetter; i <= endLetter; i++)
            {
                if (i == forbiddenLetter)
                {
                    continue;
                }
                for (char j = startLetter; j <= endLetter; j++)
                {
                    if (j == forbiddenLetter)
                    {
                        continue;
                    }

                    for (char k = startLetter; k <= endLetter; k++)
                    {
                        if (k == forbiddenLetter)
                        {
                            continue;
                        }
                        combinations++;
                        Console.Write($"{i}{j}{k} ");
                    }
                }
            }
            Console.WriteLine(combinations);
        }
    }
}
