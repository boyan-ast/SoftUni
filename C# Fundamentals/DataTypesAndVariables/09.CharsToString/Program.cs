using System;
using System.Text;

namespace _09.CharsToString
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                result.Append(symbol);
            }

            Console.WriteLine(result);
        }
    }
}
