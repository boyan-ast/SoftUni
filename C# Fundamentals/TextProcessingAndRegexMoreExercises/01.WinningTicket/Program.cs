using System;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allTickets = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string ticket in allTickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string jackpotPattern = @"(?<symbol>[@#$^])\1{9}";
                    string firstHalf = ticket.Substring(0, 10);
                    string secondHalf = ticket.Substring(10);

                    if (Regex.IsMatch(firstHalf, jackpotPattern) && Regex.IsMatch(secondHalf, jackpotPattern))
                    {
                        Match match = Regex.Match(ticket, jackpotPattern);

                        char winningSymbol = char.Parse(match.Groups["symbol"].Value);
                        Console.WriteLine($"ticket \"{ticket}\" - 10{winningSymbol} Jackpot!");
                    }
                    else
                    {
                        char symbol = ' ';
                        int symbolsNumFirstHalf = 0;
                        int symbolsNumSecondHalf = 0;
                        bool isWinning = false;
                        int minLength = 0;

                        if (Regex.IsMatch(firstHalf, @"(?<allSymbols>(?<symbol>[@#$^])\k<symbol>{5,8})"))
                        {
                            Match match = Regex.Match(firstHalf, @"(?<allSymbols>(?<symbol>[@#$^])\k<symbol>{5,8})");

                            symbol = char.Parse(match.Groups["symbol"].Value);
                            symbolsNumFirstHalf = match.Groups["allSymbols"].Value.Length;

                            if (Regex.IsMatch(secondHalf, @"(?<allSymbols>(?<symbol>[@#$^])\k<symbol>{5,8})"))
                            {
                                isWinning = true;
                                Match secondMatch = Regex.Match(firstHalf, @"(?<allSymbols>(?<symbol>[@#$^])\k<symbol>{5,8})");
                                symbolsNumSecondHalf = secondMatch.Groups["allSymbols"].Value.Length;

                                minLength = Math.Min(symbolsNumFirstHalf, symbolsNumSecondHalf);
                            }
                        }

                        if (isWinning)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {minLength}{symbol}");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }

                }
            }
        }
    }
}
