using System;
using System.Collections.Generic;
using System.Text;

namespace _07.SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int numberOfPasswords = int.Parse(Console.ReadLine());

            int passwordsCounter = 0;
            int firstSymbol = 35;
            int secondSymbol = 64;
            StringBuilder passwords = new StringBuilder();

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    passwordsCounter++;

                    if (passwordsCounter > numberOfPasswords)
                    {
                        break;
                    }

                    string password = String.Format($"{(char)(firstSymbol)}{(char)(secondSymbol)}{i}{j}{(char)(secondSymbol)}{(char)(firstSymbol)}|");                    
                    passwords.Append(password);

                    firstSymbol++;
                    secondSymbol++;

                    if (firstSymbol == 56)
                    {
                        firstSymbol = 35;
                    }
                    if (secondSymbol == 97)
                    {
                        secondSymbol = 64;
                    }
                }

                if (passwordsCounter > numberOfPasswords)
                {
                    break;
                }
            }

            Console.WriteLine(passwords);
        }
    }
}
