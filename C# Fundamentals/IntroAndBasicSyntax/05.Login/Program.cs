using System;
using System.Linq;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);
            string password = new string(charArray);

            string input = string.Empty;
            int counter = 0;

            while ((input = Console.ReadLine()) != password)
            {
                counter++;

                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");
            }

            Console.WriteLine($"User {username} logged in.");
        }
    }
}
