using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, StringBuilder> strings = new Dictionary<string, StringBuilder>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                StringBuilder reversedString = new StringBuilder(input.Length);

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedString.Append(input[i]);
                }

                strings.Add(input, reversedString);
            }

            foreach (var kvp in strings)
            {
                Console.WriteLine($"{kvp.Key} = {kvp.Value}");
            }
        }
    }
}
