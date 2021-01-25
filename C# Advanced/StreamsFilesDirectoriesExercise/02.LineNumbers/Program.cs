using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int count = 0;
            string lettersPattern = @"[A-Za-z]";
            string marksPattern = @"[.,!?;:'\(\)\[\]""\-\/@\{\}\*]";
            string[] resultLines = new string[lines.Length];

            foreach (var line in lines)
            {
                int lettersCount = Regex.Matches(line, lettersPattern).Count;
                int marksCount = Regex.Matches(line, marksPattern).Count;

                string resultLine = $"Line {++count}: {line} ({lettersCount})({marksCount})";
                resultLines[count - 1] = resultLine;                
            }

            File.WriteAllLines("../../../output.txt", resultLines);
        }
    }
}
