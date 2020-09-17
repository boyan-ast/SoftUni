using System;
using System.Text;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();

            string reversedString = ReverseString(inputStr);

            Console.WriteLine(reversedString);
        }

        private static string ReverseString(string input)
        {
            StringBuilder reversedStr = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversedStr.Append(input[i]);
            }

            return reversedStr.ToString();
        }
    }
}
