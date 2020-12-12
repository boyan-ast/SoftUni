using System;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.+)>(?<numbers>\d{3})\|(?<lowerLetters>[a-z]{3})\|(?<upperLetters>[A-Z]{3})\|(?<symbols>[^<>]{3})<\1$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string password = match.Groups["numbers"].Value +
                        match.Groups["lowerLetters"] +
                        match.Groups["upperLetters"] +
                        match.Groups["symbols"];

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
