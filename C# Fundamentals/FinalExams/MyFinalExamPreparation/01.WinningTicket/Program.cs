using System;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string winningPattern = @"[^@$#^]*(?<winningPart>(?<symbol>[@#$^])\2{5,9})[^@$#^]*";

            foreach (string ticket in input)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }

                string leftHalf = ticket.Substring(0, 10);
                string rightHalf = ticket.Substring(10);

                if (Regex.Match(leftHalf, winningPattern).Success)
                {
                    string winningSymbol = Regex.Match(leftHalf, winningPattern).Groups["symbol"].Value;
                    string leftWinningPart = Regex.Match(leftHalf, winningPattern).Groups["winningPart"].Value;
                    string rightWinningPart = string.Empty;

                    if (Regex.Match(rightHalf, winningPattern).Success)
                    {
                        rightWinningPart = Regex.Match(rightHalf, winningPattern).Groups["winningPart"].Value;

                        int minCount = Math.Min(leftWinningPart.Length, rightWinningPart.Length);

                        if (minCount == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - 10{winningSymbol} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {minCount}{winningSymbol}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
