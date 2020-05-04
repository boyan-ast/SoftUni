using System;

namespace _10.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsAtHome = int.Parse(Console.ReadLine());

            int weekendsInSofia = 48 - weekendsAtHome;
            double gamesInSofia = 0.75 * weekendsInSofia;
            gamesInSofia += 2.00 / 3 * holidays;

            double totalGames = weekendsAtHome + gamesInSofia;

            if (yearType == "leap")
            {
                totalGames *= 1.15;
            }

            Console.WriteLine($"{Math.Floor(totalGames)}");
        }
    }
}
