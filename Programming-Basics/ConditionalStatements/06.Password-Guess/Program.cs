using System;

namespace _06.Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string password = @"s3cr3t!P@ssw0rd";

            if (input != password)
            {
                Console.WriteLine("Wrong password!");
            }
            else
            {
                Console.WriteLine("Welcome");
            }    
        }
    }
}
