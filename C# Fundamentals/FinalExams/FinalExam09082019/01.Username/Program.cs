using System;
using System.Linq;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Sign up")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                if (action == "Case")
                {
                    if (commandArgs[1] == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else if (commandArgs[1] == "upper")
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (action == "Reverse")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if ((startIndex >= 0 && startIndex <= username.Length - 1) &&
                        (endIndex >= startIndex && endIndex <= username.Length - 1))
                    {
                        int length = endIndex - startIndex + 1;
                        string substring = username.Substring(startIndex, length);
                        char[] substringToCharArr = substring.ToCharArray();
                        Array.Reverse(substringToCharArr);
                        string result = new string(substringToCharArr);
                        Console.WriteLine(result);
                    }
                }
                else if (action == "Cut")
                {
                    string substring = commandArgs[1];

                    if (username.Contains(substring))
                    {
                        username = username.Replace(substring, "");
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (action == "Replace")
                {
                    char symbol = char.Parse(commandArgs[1]);
                    username = username.Replace(symbol, '*');
                    Console.WriteLine(username);
                }
                else if (action == "Check")
                {
                    char symbol = char.Parse(commandArgs[1]);

                    if (username.Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }
            }
        }
    }
}
