using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.WinningTicket_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string[] tickets = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";
            Regex rgx = new Regex(pattern);

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    result.Append($"invalid ticket{Environment.NewLine}");
                    continue;
                }

                Match leftMatch = rgx.Match(ticket.Substring(0, 10));
                Match rightMatch = rgx.Match(ticket.Substring(10));

                if (!leftMatch.Success || !rightMatch.Success)
                {
                    result.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                    continue;
                }

                int minLen = Math.Min(leftMatch.Value.Length, rightMatch.Value.Length);

                string leftPart = leftMatch.Value.Substring(0, minLen);
                string rightPart = rightMatch.Value.Substring(0, minLen);

                if (leftPart.Equals(rightPart))
                {
                    if (leftPart.Length == 10)
                    {
                        result.Append($"ticket \"{ticket}\" - {minLen}{leftPart[0]} Jackpot!{Environment.NewLine}");
                    }
                    else
                    {
                        result.Append($"ticket \"{ticket}\" - {minLen}{leftPart[0]}{Environment.NewLine}");
                    }
                }
                else
                {
                    result.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                }
            }

            Console.WriteLine(result);
        }
    }
}
