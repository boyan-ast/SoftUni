using System;

namespace _06.The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string bestWord = null;
            double bestScore = 0;

            string word = null;

            while ((word = Console.ReadLine()) != "End of words")
            {
                double score = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    score += word[i];
                }

                char firstLetter = char.ToLower(word[0]);

                switch (firstLetter)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                        score *= word.Length;
                        break;
                    default:
                        score /= word.Length;
                        score = Math.Floor(score);
                        break;
                }

                if (score >= bestScore)
                {
                    bestScore = score;
                    bestWord = word;
                }
            }

            Console.WriteLine($"The most powerful word is {bestWord} - {bestScore}");
        }
    }
}
