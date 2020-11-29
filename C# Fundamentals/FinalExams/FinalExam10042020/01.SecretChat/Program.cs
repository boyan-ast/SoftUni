using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] commandArgs = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);                

                message = PerformOperations(message, commandArgs);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        private static string PerformOperations(string message, string[] commandArgs)
        {
            string action = commandArgs[0];

            if (action == "InsertSpace")
            {
                int index = int.Parse(commandArgs[1]);
                message = message.Insert(index, " ");
                Console.WriteLine(message);
            }
            else if (action == "Reverse")
            {
                string substring = commandArgs[1];

                if (message.Contains(substring))
                {
                    int index = message.IndexOf(substring);
                    char[] substringArr = substring.ToCharArray();
                    Array.Reverse(substringArr);
                    substring = new string(substringArr);
                    message = message.Remove(index, substring.Length);
                    message = message.Insert(message.Length, substring);

                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (action == "ChangeAll")
            {
                message = ChangeSubstrings(message, commandArgs[1], commandArgs[2]);
                Console.WriteLine(message);
            }

            return message;
        }

        private static string ChangeSubstrings(string message, string substring, string replacement)
        {
            int index = message.IndexOf(substring);

            while (index != -1)
            {
                message = message.Remove(index, substring.Length);
                message = message.Insert(index, replacement);

                index = message.IndexOf(substring);
            }            

            return message;
        }
    }
}
