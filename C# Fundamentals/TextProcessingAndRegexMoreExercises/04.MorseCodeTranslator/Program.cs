using System;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder decryptedText = new StringBuilder();


            foreach (string word in words)
            {
                string[] letters = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < letters.Length; i++)
                {
                    char letter = FindTheLetter(letters[i]);
                    decryptedText.Append(letter.ToString().ToUpper());
                }

                decryptedText.Append(" ");
            }

            Console.WriteLine(decryptedText.ToString().Trim());
        }

        static char FindTheLetter(string letterCode)
        {
            switch (letterCode)
            {
                case ".-": return 'a';
                case "-...": return 'b';
                case "-.-.": return 'c';
                case "-..": return 'd';
                case ".": return 'e';
                case "..-.": return 'f';
                case "--.": return 'g';
                case "....": return 'h';
                case "..": return 'i';
                case ".---": return 'j';
                case "-.-": return 'k';
                case ".-..": return 'l';
                case "--": return 'm';
                case "-.": return 'n';
                case "---": return 'o';
                case ".--.": return 'p';
                case "--.-": return 'q';
                case ".-.": return 'r';
                case "...": return 's';
                case "-": return 't';
                case "..-": return 'u';
                case "...-": return 'v';
                case ".--": return 'w';
                case "-..-": return 'x';
                case "-.--": return 'y';
                case "--..": return 'z';
                default: return ' ';
            }
        }
    }
}
