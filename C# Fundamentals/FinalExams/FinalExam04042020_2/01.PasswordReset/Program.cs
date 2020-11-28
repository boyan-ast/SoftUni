using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                if (action == "TakeOdd")
                {
                    StringBuilder newString = new StringBuilder();

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            newString.Append(password[i].ToString());
                        }
                    }

                    password = newString.ToString();

                    Console.WriteLine(password);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(commandArgs[1]);
                    int length = int.Parse(commandArgs[2]);

                    password = password.Remove(index, length);

                    Console.WriteLine(password);
                }
                else if (action == "Substitute")
                {
                    string substring = commandArgs[1];
                    string substitute = commandArgs[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
