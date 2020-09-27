using System;
using System.Linq;

namespace _01.EncryptSortAndPrintArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] encryptedCodes = new int[n];

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();           

                int sum = WordCalculator(word);

                encryptedCodes[i] = sum;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (encryptedCodes[i] > encryptedCodes[j])
                    {
                        int temp = encryptedCodes[i];
                        encryptedCodes[i] = encryptedCodes[j];
                        encryptedCodes[j] = temp;
                    }
                }
            }

            foreach (var code in encryptedCodes)
            {
                Console.WriteLine(code);
            }
        }

        private static int WordCalculator(string word)
        {
            int length = word.Length;
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                string symbol = word[i].ToString().ToLower();
                bool isVowel = symbol == "a" || symbol == "e" || symbol == "i" || symbol == "o" || symbol == "u";

                if (isVowel)
                {
                    sum += word[i] * length;
                }
                else
                {
                    sum += word[i] / length;
                }
            }

            return sum;
        }
    }
}
