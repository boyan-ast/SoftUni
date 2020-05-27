using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());

            int additionRows = 0;
            int totalSeats = 0;

            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                for (int row = 1; row <= rows + additionRows; row++)
                {
                    int finalSeat = 0;

                    if (row % 2 == 0)
                    {
                        finalSeat= 'a' + seats + 2;
                    }
                    else
                    {
                        finalSeat = 'a' + seats;
                    }

                    for (char seat = 'a'; seat < finalSeat; seat++)
                    {
                        totalSeats++;
                        Console.WriteLine($"{sector}{row}{seat}");
                    }
                }

                additionRows++;
            }

            Console.WriteLine(totalSeats);
        }
    }
}
