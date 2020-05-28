using System;
using System.Collections.Generic;

namespace _03.StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            bool cLetterFound = false;
            bool oLetterFound = false;
            bool nLetterFound = false;

            string command = String.Empty;
            string word = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                char letter = char.Parse(command);

                if (!char.IsLetter(letter))
                {
                    continue;
                }

                if (letter == 'c' && !cLetterFound)
                {
                    cLetterFound = true;
                    if (oLetterFound && nLetterFound)
                    {                        
                        words.Add(word);                        
                        word = string.Empty;
                        cLetterFound = false;
                        oLetterFound = false;
                        nLetterFound = false;
                    }

                    continue;
                }
                else if (letter == 'o' && !oLetterFound)
                {
                    oLetterFound = true;
                    if (cLetterFound && nLetterFound)
                    {                        
                        words.Add(word);                        
                        word = string.Empty;
                        cLetterFound = false;
                        oLetterFound = false;
                        nLetterFound = false;
                    }
                    continue;
                }
                else if (letter == 'n' && !nLetterFound)
                {
                    nLetterFound = true;
                    if (oLetterFound && cLetterFound)
                    {                        
                        words.Add(word);                        
                        word = string.Empty;
                        cLetterFound = false;
                        oLetterFound = false;
                        nLetterFound = false;
                    }
                    continue;
                }

                word += letter.ToString();
            }

            Console.WriteLine(string.Join(" ",words));
            
        }
    }
}
