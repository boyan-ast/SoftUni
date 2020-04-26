using System;

namespace _05.Time_Plus_15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            TimeSpan time = new TimeSpan(hours, minutes, 0);
            TimeSpan finalTime = time.Add(new TimeSpan(0, 15, 0));

            Console.WriteLine(finalTime.ToString(@"h\:mm"));         

        }
    }
}
