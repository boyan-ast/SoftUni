﻿using System;
using System.Text;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;

            while ((word = Console.ReadLine()) != "end")
            {
                StringBuilder reversedWord = new StringBuilder();

                for (int i = word.Length - 1; i >= 0 ; i--)
                {
                    reversedWord.Append(word[i]);
                }

                Console.WriteLine($"{word} = {reversedWord}");
            }
        }
    }
}
