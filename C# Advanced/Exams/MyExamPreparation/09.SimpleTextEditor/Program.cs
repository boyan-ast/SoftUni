using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> textHistory = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int commandType = int.Parse(command[0]);

                if (commandType == 1)
                {
                    textHistory.Push(text);
                    string substring = command[1];
                    text += substring;
                }
                else if (commandType == 2)
                {
                    textHistory.Push(text);

                    int count = int.Parse(command[1]);

                    if (count <= text.Length)
                    {
                        text = text.Remove(text.Length - count);
                    }
                }
                else if (commandType == 3)
                {
                    int index = int.Parse(command[1]);
                    if (index - 1 >= 0 && index - 1 < text.Length)
                    {
                        Console.WriteLine(text[index - 1]);
                    }
                }
                else if (commandType == 4)
                {
                    if (textHistory.Count > 0)
                    {
                        text = textHistory.Pop();
                    }
                }
            }
        }
    }
}
