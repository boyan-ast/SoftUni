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
                        string allSymbols = string.Empty;
                        bool isWinning = false;

                        if (Regex.IsMatch(firstHalf, @"(?<allSymbols>(?<symbol>[@#$^])\k<symbol>{5,8})"))
                        {
                            Match match = Regex.Match(firstHalf, @"(?<allSymbols>(?<symbol>[@#$^])\k<symbol>{5,8})");

                            symbol = char.Parse(match.Groups["symbol"].Value);
                            allSymbols = match.Groups["allSymbols"].Value;

                            if (secondHalf.Contains(allSymbols))
                            {
                                isWinning = true;
                            }
                        }

                        if (isWinning)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {allSymbols.Length}{symbol}");
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
