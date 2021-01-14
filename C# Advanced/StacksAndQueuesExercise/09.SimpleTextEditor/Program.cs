using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stringsHistory = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                int command = int.Parse(input[0]);

                if (command == 1)
                {
                    stringsHistory.Push(text.ToString());

                    string textToAppend = input[1];
                    text.Append(textToAppend);
                }
                else if (command == 2)
                {
                    stringsHistory.Push(text.ToString());

                    int count = int.Parse(input[1]);

                    if (count > text.Length)
                    {
                        count = text.Length;
                    }

                    text = text.Remove(text.Length - count, count);
                }
                else if (command == 3)
                {
                    int index = int.Parse(input[1]);

                    if (index >= 1 && index <= text.Length)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (command == 4)
                {
                    if (stringsHistory.Count > 0)
                    {
                        text = new StringBuilder(stringsHistory.Pop());
                    }
                }
            }
        }
    }
}
