using System;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string encryptedText = Console.ReadLine();

            while (encryptedText != "find")
            {
                StringBuilder decryptedText = new StringBuilder(encryptedText.Length);

                int iterations = 0;

                for (int i = 0; i < encryptedText.Length; i++)
                {
                    int key = keys[i - iterations * keys.Length];

                    decryptedText.Append((char)(encryptedText[i] - key));

                    if (i - iterations * keys.Length == keys.Length - 1)
                    {
                        iterations++;
                    }
                }

                int startIndexOfType = decryptedText.ToString().IndexOf('&') + 1;
                int endIndexOfType = decryptedText.ToString().LastIndexOf('&');
                int typeLength = endIndexOfType - startIndexOfType;

                string type = decryptedText.ToString().Substring(startIndexOfType, typeLength);

                int startIndexOfCoord = decryptedText.ToString().IndexOf('<') + 1;
                int endIndexOfCoord = decryptedText.ToString().LastIndexOf('>');
                int coordinatesLength = endIndexOfCoord - startIndexOfCoord;

                string coordinates = decryptedText.ToString().Substring(startIndexOfCoord, coordinatesLength);

                Console.WriteLine($"Found {type} at {coordinates}");

                encryptedText = Console.ReadLine();
            }

        }
    }
}
