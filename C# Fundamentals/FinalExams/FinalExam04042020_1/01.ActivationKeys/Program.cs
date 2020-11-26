using System;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandArgs = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];

                if (action == "Contains")
                {
                    string substring = commandArgs[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string newType = commandArgs[1];
                    int startIndex = int.Parse(commandArgs[2]);
                    int endIndex = int.Parse(commandArgs[3]);
                    int length = endIndex - startIndex;

                    string substring = input.Substring(startIndex, length);

                    if (newType == "Upper")
                    {
                        input = input.Replace(substring, substring.ToUpper());
                    }
                    else if (newType == "Lower")
                    {
                        input = input.Replace(substring, substring.ToLower());
                    }

                    Console.WriteLine(input);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    input = input.Remove(startIndex, (endIndex - startIndex));
                    Console.WriteLine(input);
                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
