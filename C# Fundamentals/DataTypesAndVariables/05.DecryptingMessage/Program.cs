using System;
using System.Text;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int characters = int.Parse(Console.ReadLine());
            StringBuilder message = new StringBuilder(characters);

            for (int i = 0; i < characters; i++)
            {
                char symbol = char.Parse(Console.ReadLine());

                message.Append((char)(symbol + key));
            }

            Console.WriteLine(message);
        }
    }
}
