using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder resultText = new StringBuilder();
            resultText.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i-1])
                {
                    resultText.Append(input[i]);
                }
            }

            Console.WriteLine(resultText);
        }
    }
}
