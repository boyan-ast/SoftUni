using System;
using System.Collections.Generic;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int totalTicketsSold = 0;
            Dictionary<string, int> seatsType = new Dictionary<string, int>
                {
                    { "student", 0 },
                    { "standard", 0 },
                    { "kid", 0 }
                };

            while (movieName != "Finish")
            {
                int seats = int.Parse(Console.ReadLine());                

                string ticketType = string.Empty;
                int occupiedSeats = 0;

                while ((ticketType = Console.ReadLine()) != "End")
                {
                    seatsType[ticketType]++;
                    occupiedSeats++;
                    totalTicketsSold++;

                    if (occupiedSeats == seats)
                    {
                        break;
                    }
                }

                Console.WriteLine($"{movieName} - {(occupiedSeats * 1.0 / seats * 100):f2}% full.");

                movieName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTicketsSold}");

            foreach (var kvp in seatsType)
            {
                if (kvp.Key != "kid")
                {
                    Console.WriteLine($"{(kvp.Value * 1.0 / totalTicketsSold * 100):f2}% {kvp.Key} tickets.");
                }
                else
                {
                    Console.WriteLine($"{(kvp.Value * 1.0 / totalTicketsSold * 100):f2}% {kvp.Key}s tickets.");
                }
            }
        }
    }
}
