using System;

namespace _04.CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int) (years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days:f0} days = {hours:f0} hours = {minutes:f0} minutes");
        }
    }
}
