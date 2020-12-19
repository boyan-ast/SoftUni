using System;
using System.Text;

namespace _01.Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Complete")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];

                if (action == "Make")
                {
                    if (tokens[1] == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else if (tokens[1] == "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (action == "GetDomain")
                {
                    int count = int.Parse(tokens[1]);
                    int startIndex = input.Length - count;
                    string domain = input.Substring(startIndex);
                    Console.WriteLine(domain);
                }
                else if (action == "GetUsername")
                {
                    int index = input.IndexOf('@');

                    if (index == -1)
                    {
                        Console.WriteLine($"The email {input} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        int length = index;
                        string substring = input.Substring(0, length);
                        Console.WriteLine(substring);
                    }
                }
                else if (action == "Replace")
                {
                    char symbol = char.Parse(tokens[1]);
                    input = input.Replace(symbol, '-');
                    Console.WriteLine(input);
                }
                else if (action == "Encrypt")
                {
                    StringBuilder encryptedText = new StringBuilder();
                    for (int i = 0; i < input.Length; i++)
                    {
                        encryptedText.Append(((int)input[i]).ToString() + " ");
                    }

                    string result = encryptedText.ToString().Trim();

                    Console.WriteLine(result);
                }
            }
        }
    }
}
