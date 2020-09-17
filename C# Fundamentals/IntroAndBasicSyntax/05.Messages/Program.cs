using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int lettersNum = int.Parse(Console.ReadLine());
            StringBuilder message = new StringBuilder();

            Dictionary<int, List<char>> keyboard = new Dictionary<int, List<char>>
            {
                { 1, new List<char>() },
                { 2, new List<char>() {'a', 'b', 'c'} },
                { 3, new List<char>() {'d', 'e', 'f'} },
                { 4, new List<char>() {'g', 'h', 'i'} },
                { 5, new List<char>() {'j', 'k', 'l'} },
                { 6, new List<char>() {'m', 'n', 'o'} },
                { 7, new List<char>() {'p', 'q', 'r', 's'} },
                { 8, new List<char>() {'t', 'u', 'v'} },
                { 9, new List<char>() {'w', 'x', 'y', 'z'} },
                { 0, new List<char>() {' '} }
            };

            for (int i = 0; i < lettersNum; i++)
            {
                int num = int.Parse(Console.ReadLine());
                int count = num.ToString().Length;

                num = num % 10;

                char symbol = keyboard[num][count - 1];
                message.Append(symbol);
            }

            Console.WriteLine(message);

        }
    }
}
