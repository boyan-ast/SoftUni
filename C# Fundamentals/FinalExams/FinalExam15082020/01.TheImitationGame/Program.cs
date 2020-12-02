using System;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] instructions = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = instructions[0];

                if (action == "Move")
                {
                    int numOfLetters = int.Parse(instructions[1]);

                    if (numOfLetters > 0 && numOfLetters < message.Length)
                    {
                        message.Append(message.ToString().Substring(0, numOfLetters));
                        message.Remove(0, numOfLetters);
                    }
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(instructions[1]);
                    string value = instructions[2];

                    if (index >= 0 && index <= message.Length)
                    {
                        message.Insert(index, value);
                    }

                }
                else if (action == "ChangeAll")
                {
                    string substring = instructions[1];
                    string replacement = instructions[2];

                    if (message.ToString().Contains(substring))
                    {
                        message.Replace(substring, replacement);
                    }
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
