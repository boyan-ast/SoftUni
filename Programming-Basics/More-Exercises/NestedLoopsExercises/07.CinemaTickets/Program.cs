using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = string.Empty;
            Dictionary<string, int> tickets = new Dictionary<string, int>()
            {
                { "student", 0 },
                { "standard", 0 },
                { "kid", 0 }
            };

            while ((movieName = Console.ReadLine()) != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());

                int ticketsSold = 0;

                while (ticketsSold < seats)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    ticketsSold++;

                    tickets[ticketType]++;
                }

                Console.WriteLine($"{movieName} - {(ticketsSold * 1.0 / seats * 100):f2}% full.");
            }

            int totalTicketsSold = tickets.Sum(x => x.Value);
            Console.WriteLine($"Total tickets: {totalTicketsSold}");

            foreach (var kvp in tickets)
            {
                if (kvp.Key == "kid")
                {
                    Console.WriteLine($"{(kvp.Value * 1.0 / totalTicketsSold * 100):f2}% {kvp.Key}s tickets.");
                }
                else
                {
                    Console.WriteLine($"{(kvp.Value * 1.0 / totalTicketsSold * 100):f2}% {kvp.Key} tickets.");
                }
            }
        }
    }
}
